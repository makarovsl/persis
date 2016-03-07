using System;
using Core.Models.Product;

namespace Core.OperationInterfaces
{
    public interface IProductAction
    {
        int GetListCount();
        ProductListAnswer[] GetList(ProductListModel listModel);
        ProductDetailAnswer GetDetail(Guid id);
        Guid Add(ProductAddModel addModel);
        Guid Update(ProductUpdateModel updateModel);
        void Delete(Guid id);
    }
}