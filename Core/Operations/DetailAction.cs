using System;
using System.Linq;
using System.Transactions;
using Core.Models;
using Core.Models.Detail;
using Core.OperationInterfaces;
using DAL.Common.DbEntity;
using DAL.Common.DbInterface;
using DAL.Entity;

namespace Core.Operations
{
    public class DetailAction : IDetailAction
    {
        private readonly IRemovableEntityDb<Detail> _detail;
        private readonly IM2MEntityDb<MaterialOfDetail> _detailMaterial;
        private readonly IM2MEntityDb<DetailOfProduct> _productDetail;

        public DetailAction(IRemovableEntityDb<Detail> detail,
                            IM2MEntityDb<MaterialOfDetail> detailMaterial,
                            IM2MEntityDb<DetailOfProduct> productDetail)
        {
            _detail = detail;
            _detailMaterial = detailMaterial;
            _productDetail = productDetail;
        }

        /// <summary>
        /// Получение количества деталей в БД для пэйджинга
        /// </summary>
        /// <returns>Количество деталей</returns>
        public int GetListCount()
        {
            return _detail.GetCollection().Count();
        }

        /// <summary>
        /// Получение списка деталей
        /// </summary>
        /// <param name="listModel"></param>
        /// <returns></returns>
        public DetailListAnswer[] GetList(DetailListModel listModel)
        {
            if (listModel.PageNumber <= 0 || listModel.PageSize <= 0)
                return new DetailListAnswer[0];
            return
                _detail.GetCollection()
                    .OrderBy(o => new { o.Name, o.Id })
                    .Select(s => new DetailListAnswer
                    {
                        Id = s.Id,
                        Name = s.Name
                    })
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
            return _detail.GetCollection().OrderBy(o => o.Name).Select(s => new SimpleListItem
            {
                Id = s.Id,
                Name = s.Name
            }).ToArray();
        }


        /// <summary>
        /// Получение деталей сущности "Детали"
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public DetailDetailAnswer GetDetail(Guid id)
        {
            var detail = _detail.GetByIdWithInclude(id);
            if (detail == null)
                throw new Exception("Деталь не найдена");

            return new DetailDetailAnswer
            {
                Id = detail.Id,
                Name = detail.Name,
                Materials = detail.MaterialsOfDetail.Select(s => new ContainObjectItem
                {
                    Id = s.MaterialId,
                    Count = s.MaterialCount
                }).ToList()
            };
        }

        /// <summary>
        /// Обновление состава полей сущности "Деталь"
        /// </summary>
        /// <param name="updateModel">Модель с данными</param>
        /// <returns>Идентификатор сущности</returns>
        public Guid Update(DetailUpdateModel updateModel)
        {
            if (String.IsNullOrEmpty(updateModel.Name))
                throw new Exception("Имя не может быть пустым");

            using (var transaction = new TransactionScope())
            {
                _detail.Update(updateModel.GetEntity());
                var modList = updateModel.GetMaterialOfDetailEntity();

                var materialIds = modList.Select(s => s.MaterialId).ToArray();

                modList.ForEach(p => _detailMaterial.Upsert(p));

                _detailMaterial.GetCollection()
                    .Where(
                        w => w.DetailId.Equals(updateModel.Id) &&
                             !materialIds.Contains(w.MaterialId))
                    .ToList()
                    .ForEach(f => _detailMaterial.Delete(f.DetailId, f.MaterialId));

                transaction.Complete();
            }


            return updateModel.Id;
        }

        /// <summary>
        /// Добавление новой детали
        /// </summary>
        /// <param name="addModel">Модель добавления</param>
        /// <returns>Идентификатор детали</returns>
        public Guid Add(DetailAddModel addModel)
        {
            if (String.IsNullOrEmpty(addModel.Name))
                throw new Exception("Имя не может быть пустым");

            Guid newId;
            using (var transaction = new TransactionScope())
            {
                newId = _detail.Insert(addModel.GetEntity());

                var modList = addModel.GetMaterialOfDetailEntity(newId);

                modList.ForEach(p => _detailMaterial.Upsert(p));

                transaction.Complete();
            }

            return newId;
        }

        public void Delete(Guid id)
        {
            using (var transaction = new TransactionScope())
            {
                if (_productDetail.GetCollection().Any(a => a.DetailId.Equals(id)))
                {
                    transaction.Dispose();
                    throw new Exception("Деталь используется в изделиях");
                }
                _detail.Delete(id);
                transaction.Complete();
            }
        }
    }
}