using System;
using System.Linq;
using System.Transactions;
using Core.Models;
using Core.Models.Detail;
using Core.OperationInterfaces;
using DAL.Common.DbEntity;
using DAL.Entity;

namespace Core.Operations
{
    public class DetailAction : IDetailAction
    {
        private readonly IRemovableEntityDb<Detail> _detail;
        
        public DetailAction(IRemovableEntityDb<Detail> detail)
        {
            _detail = detail;
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
                    .OrderBy(o => new {o.Name, o.Id})
                    .Select(s=>new DetailListAnswer
                    {
                        Id = s.Id,
                        Name = s.Name
                    })
                    .Skip((listModel.PageNumber - 1)*listModel.PageSize)
                    .Take(listModel.PageSize)
                    .ToArray();
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
                Materials = detail.MaterialsOfDetail.Select(s=> new ContainObjectItem
                {
                    Id = s.MaterialId,
                    Count = s.MaterialCount
                }).ToList()
            };
        }

        public Guid UpdateDetail(DetailUpdateModel updateModel)
        {
            if(String.IsNullOrEmpty(updateModel.Name))
                throw new Exception("Имя не может быть пустым");

            using (var transaction = new TransactionScope())
            {
                _detail.Update(updateModel.GetEntity());

                transaction.Complete();
            }


            return updateModel.Id;
        }
    }
}