using System;
using System.Linq;
using Core.Models;
using Core.Models.Detail;
using Core.Models.Material;
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

        public int GetListCount()
        {
            return _detail.GetCollection().Count();
        }

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

        public DetailDetailAnswer GetDetail(Guid id)
        {
            var detail = _detail.GetByIdWithInclude(id);
            if (detail == null)
                throw new Exception("Деталь не найдена");

            return new DetailDetailAnswer
            {
                Id = detail.Id,
                Name = detail.Name,
                Materials = detail.MaterialsOfDetail.Select(s=> new MaterialOfDetailItem
                {
                    MaterialId = s.MaterialId,
                    MaterialName = s.Material.Name,
                    MaterialCount = s.MaterialCount
                }).ToArray()
            };
        }
    }
}