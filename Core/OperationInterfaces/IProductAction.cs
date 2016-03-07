using Core.Models.Product;

namespace Core.OperationInterfaces
{
    public interface IProductAction
    {
        int GetListCount();
        ProductListAnswer[] GetList(ProductListModel listModel);
    }
}