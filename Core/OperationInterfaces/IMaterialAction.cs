using System;
using System.Collections.Generic;
using Core.Models;
using Core.Models.Material;

namespace Core.OperationInterfaces
{
    /// <summary>
    /// Интерфейс операций с материалами
    /// </summary>
    public interface IMaterialAction
    {
        Guid Add(MaterialAddModel addModel);
        int GetListCount();
        MaterialListAnswer[] GetList(MaterialListModel listModel);
        SimpleListItem[] GetSimpleList();
        MaterialDetailAnswer GetDetail(Guid id);
        Guid Update(MaterialUpdateModel updateModel);
        void Delete(Guid id);
    }
}
