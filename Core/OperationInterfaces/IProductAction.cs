using System;
using Core.Models.Product;

namespace Core.OperationInterfaces
{
    public interface IProductAction : ISaveAction<ProductUpdateModel, ProductAddModel, ProductDetailAnswer>
    {
        int GetListCount();
        ProductListAnswer[] GetList(ProductListModel listModel);
        void Delete(Guid id);
    }
}