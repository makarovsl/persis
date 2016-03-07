using System;
using System.Linq;
using System.Transactions;
using Core.Models;
using Core.Models.Product;
using Core.OperationInterfaces;
using DAL.Common.DbEntity;
using DAL.Common.DbInterface;
using DAL.Entity;

namespace Core.Operations
{
    public class ProductAction : IProductAction
    {
        private readonly IEntityDb<Product> _product;
        private readonly IM2MEntityDb<DetailOfProduct> _detailOfProduct;

        public ProductAction(IEntityDb<Product> product,
                             IM2MEntityDb<DetailOfProduct> detailOfProduct)
        {
            _product = product;
            _detailOfProduct = detailOfProduct;
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

        public ProductDetailAnswer GetDetail(Guid id)
        {
            var product = _product.GetByIdWithInclude(id);

            if (product == null)
                throw new Exception("Изделие не найдено");

            return new ProductDetailAnswer
            {
                Id = product.Id,
                Name = product.Name,
                Details = product.DetailsOfProduct.Select(s => new ContainObjectItem
                {
                    Id = s.DetailId,
                    Count = s.DetailCount
                }).ToList()
            };
        }

        //todo подуамть над вынесением в абстракцию
        public Guid Update(ProductUpdateModel updateModel)
        {
            if (String.IsNullOrEmpty(updateModel.Name))
                throw new Exception("Имя не может быть пустым");

            using (var transaction = new TransactionScope())
            {
                _product.Update(updateModel.GetEntity());
                var modList = updateModel.GetMaterialOfDetailEntity();

                var materialIds = modList.Select(s => s.DetailId).ToArray();

                modList.ForEach(p => _detailOfProduct.Upsert(p));

                _detailOfProduct.GetCollection()
                    .Where(
                        w => w.ProductId.Equals(updateModel.Id) &&
                             !materialIds.Contains(w.DetailId))
                    .ToList()
                    .ForEach(f => _detailOfProduct.Delete(f.ProductId, f.DetailId));

                transaction.Complete();
            }
            return updateModel.Id;
        }
        
        public Guid Add(ProductAddModel addModel)
        {
            if (String.IsNullOrEmpty(addModel.Name))
                throw new Exception("Имя не может быть пустым");

            Guid newId;
            using (var transaction = new TransactionScope())
            {
                newId = _product.Insert(addModel.GetEntity());

                var modList = addModel.GetMaterialOfDetailEntity(newId);

                modList.ForEach(p => _detailOfProduct.Upsert(p));

                transaction.Complete();
            }

            return newId;
        }

        public void Delete(Guid id)
        {
            using (var transaction = new TransactionScope())
            {
                _product.Delete(id);
                transaction.Complete();
            }
        }

    }
}