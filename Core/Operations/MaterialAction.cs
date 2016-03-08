using System;
using System.Linq;
using System.Transactions;
using Core.Models;
using Core.Models.Material;
using Core.OperationInterfaces;
using DAL.Common.DbEntity;
using DAL.Common.DbInterface;
using DAL.Entity;

namespace Core.Operations
{
    public class MaterialAction : IMaterialAction
    {
        private readonly IRemovableEntityDb<Material> _material;
        private readonly IM2MEntityDb<MaterialOfDetail> _materialOfDetails;
        private readonly IEntityDb<MaterialOperation> _materialOperation;

        public MaterialAction(IRemovableEntityDb<Material> material,
                              IM2MEntityDb<MaterialOfDetail> materialOfDetails,
                              IEntityDb<MaterialOperation> materialOperation)
        {
            _material = material;
            _materialOperation = materialOperation;
            _materialOfDetails = materialOfDetails;
        }

        /// <summary>
        /// Функция добавления материала
        /// </summary>
        /// <param name="addModel">Входящая модель</param>
        /// <returns>Идентификатор созданного материала</returns>
        public Guid Add(MaterialAddModel addModel)
        {
            if (String.IsNullOrEmpty(addModel.Name))
                throw new Exception("Наименование не должно быть пустым");

            if (addModel.Count < 0 || addModel.Count > 999999999)
                    throw new Exception("Количество должно быть в интервале 0 - 999999999");
            

            Guid newId;
            using (var transaction = new TransactionScope())
            {
                newId = _material.Insert(addModel.GetEntity());
                if ((addModel.Count) != 0)
                    _materialOperation.Insert(new MaterialOperation { MaterialId = newId, Count = addModel.Count});
                transaction.Complete();
            }
            return newId;
        }

        /// <summary>
        /// Получение количества материалов в БД для пэйджинга
        /// </summary>
        /// <returns>Количество материалов в БД</returns>
        public int GetListCount()
        {
            return _material.GetCollection().Count();
        }

        /// <summary>
        /// Получение списка материалов
        /// </summary>
        /// <param name="listModel">Параметры пэйджинга</param>
        /// <returns>Массив моделей для табличного представления</returns>
        public MaterialListAnswer[] GetList(MaterialListModel listModel)
        {
            if (listModel.PageNumber <= 0 || listModel.PageSize <= 0)
                return new MaterialListAnswer[0];

            return _material.GetIncludedCollection()
                .GroupBy(g => new { g.Name, g.Id })
                .Select(
                    s =>
                        new MaterialListAnswer
                        {
                            Id = s.Key.Id,
                            Name = s.Key.Name,
                            Count =
                                s.Sum(
                                    su => su.MaterialOperations.Any() ? su.MaterialOperations.Sum(q => q.Count) : 0)
                        }).OrderBy(o => new { o.Name, o.Id })
                .Skip((listModel.PageNumber - 1) * listModel.PageSize)
                .Take(listModel.PageSize)
                .ToArray();
        }

        /// <summary>
        /// Простой список материалов
        /// </summary>
        /// <returns>Ключ - id материала, Значение - название</returns>
        public SimpleListItem[] GetSimpleList()
        {
            return _material.GetCollection().OrderBy(o => o.Name).Select(s => new SimpleListItem
            {
                Id = s.Id,
                Name = s.Name
            }).ToArray();
        }

        /// <summary>
        /// Получение деталей материала
        /// </summary>
        /// <param name="id">Идентификатор материала</param>
        /// <returns>Модель представления деталей материала</returns>
        public MaterialDetailAnswer GetDetail(Guid id)
        {
            var entity =
                 _material.GetIncludedCollection()
                     .Where(w => w.Id == id)
                     .GroupBy(g => new { g.Id, g.Name })
                     .Select(
                         s =>
                             new MaterialDetailAnswer
                             {
                                 Id = s.Key.Id,
                                 Name = s.Key.Name,
                                 Count =
                                     s.Sum(
                                         su => su.MaterialOperations.Any() ? su.MaterialOperations.Sum(q => q.Count) : 0)
                             }).SingleOrDefault();

            if (entity == null)
                throw new Exception("Материал не найден");

            return entity;

        }

        /// <summary>
        /// Обновление свойств материалов
        /// </summary>
        /// <param name="updateModel">Модель с обновленными данными</param>
        /// <returns>Идентификатор объекта</returns>
        public Guid Update(MaterialUpdateModel updateModel)
        {
            if (updateModel.Id.Equals(Guid.Empty))
                throw new Exception("Не заполнен идентификатор");

            if (String.IsNullOrEmpty(updateModel.Name))
                throw new Exception("Не заполнено наименование");

            using (var transaction = new TransactionScope())
            {
                var operationCount = updateModel.Count - _materialOperation.GetCollection()
                                         .Where(w => w.MaterialId.Equals(updateModel.Id))
                                         .DefaultIfEmpty()
                                         .Sum(su => su == null ? 0 : su.Count);

                _material.Update(updateModel.GetEntity());
                if (operationCount != 0)
                    _materialOperation.Insert(new MaterialOperation
                    {
                        MaterialId = updateModel.Id,
                        Count = operationCount
                    });
                transaction.Complete();
            }

            return updateModel.Id;
        }

        public void Delete(Guid id)
        {
            using (var transaction = new TransactionScope())
            {
                if (_materialOfDetails.GetCollection().Any(a => a.MaterialId.Equals(id)))
                {
                    transaction.Dispose();
                    throw new Exception("Материал используется в деталях");
                }

                _material.Delete(id);

                transaction.Complete();
            }
        }
    }
}
