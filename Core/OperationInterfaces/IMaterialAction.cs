using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.Models.Material;

namespace Core.OperationInterfaces
{
    /// <summary>
    /// Интерфейс операций с материалами
    /// </summary>
    public interface IMaterialAction : ISaveAction<MaterialUpdateModel, MaterialAddModel, MaterialDetailAnswer>
    {
        int GetListCount();
        MaterialListAnswer[] GetList(MaterialListModel listModel);
        SimpleListItem[] GetSimpleList();
        void Delete(Guid id);
        IQueryable<MaterialWithCount> GetMaterialQuery();

        void DecreaseCount(Guid materialId, decimal countDecrease);
    }
}
