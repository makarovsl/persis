using System;
using Core.Models;
using Core.Models.Detail;

namespace Core.OperationInterfaces
{
    public interface IDetailAction : ISaveAction<DetailUpdateModel, DetailAddModel, DetailDetailAnswer>
    {
        int GetListCount();
        DetailListAnswer[] GetList(DetailListModel listModel);
        SimpleListItem[] GetSimpleList();
        void Delete(Guid id);
    }
}