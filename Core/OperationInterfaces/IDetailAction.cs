using System;
using Core.Models;
using Core.Models.Detail;

namespace Core.OperationInterfaces
{
    public interface IDetailAction
    {
        int GetListCount();
        DetailListAnswer[] GetList(DetailListModel listModel);
        SimpleListItem[] GetSimpleList();
        DetailDetailAnswer GetDetail(Guid id);
        Guid Update(DetailUpdateModel updateModel);
        Guid Add(DetailAddModel addModel);
        void Delete(Guid id);
    }
}