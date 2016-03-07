using System.Linq;
using Core.Models.Product;
using Core.OperationInterfaces;
using DAL.Common.DbEntity;
using DAL.Entity;

namespace Core.Operations
{
    public class ProductAction : IProductAction
    {
        private readonly IEntityDb<Product> _product;

        public ProductAction(IEntityDb<Product> product)
        {
            _product = product;
        }

        public int GetListCount()
        {
            return _product.GetCollection().Count();
        }

        public ProductListAnswer[] GetList(ProductListModel listModel)
        {
            return _product.GetCollection().Select(s => new ProductListAnswer
            {
                Id = s.Id,
                Name = s.Name
            }).ToArray();
        }
    }
}