using System;
using Core.Models.Detail;

namespace Core.OperationInterfaces
{
    public interface IDetailAction
    {
        int GetListCount();
        DetailListAnswer[] GetList(DetailListModel listModel);

        DetailDetailAnswer GetDetail(Guid id);
    }
}