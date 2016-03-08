using System;
using System.Linq;
using System.Text;
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
        private readonly IM2MEntityDb<MaterialOfDetail> _materialOfDetail;
        private readonly IMaterialAction _materialAction;

        public ProductAction(IEntityDb<Product> product,
            IM2MEntityDb<DetailOfProduct> detailOfProduct,
            IM2MEntityDb<MaterialOfDetail> materialOfDetail,
            IMaterialAction materialAction)
        {
            _product = product;
            _detailOfProduct = detailOfProduct;
            _materialOfDetail = materialOfDetail;
            _materialAction = materialAction;
        }

        /// <summary>
        /// Получение количества изделий в БД, для пэйджинга
        /// </summary>
        /// <returns></returns>
        public int GetListCount()
        {
            return _product.GetCollection().Count();
        }

        /// <summary>
        /// Получение запроса по потребности материалов на производство продукта
        /// </summary>
        /// <returns></returns>
        private IQueryable<MaterialOfProduct> GetProductMaterialQuery()
        {
            return
                _product.GetCollection()
                    .Join(
                        _detailOfProduct.GetCollection(),
                        p => p.Id,
                        dop => dop.ProductId,
                        (p, dp) => new { p.Name, dp.ProductId, dp.DetailId, dp.DetailCount }
                    )
                    .Join(_materialOfDetail.GetCollection(),
                        dop => dop.DetailId,
                        mod => mod.DetailId,
                        (d, m) =>
                            new
                            {
                                d.Name,
                                d.ProductId,
                                m.MaterialId,
                                MaterialCount = m.MaterialCount * d.DetailCount
                            })
                    .GroupBy(g => new { g.ProductId, g.Name, g.MaterialId })
                    .Select(
                        s =>
                            new MaterialOfProduct
                            {
                                ProductName = s.Key.Name,
                                ProductId = s.Key.ProductId,
                                MaterialId = s.Key.MaterialId,
                                MaterialCount = s.Sum(su => su.MaterialCount)
                            });

        }

        /// <summary>
        /// Получение списка узделий
        /// </summary>
        /// <param name="listModel">Модель отборов списка</param>
        /// <returns></returns>
        public ProductListAnswer[] GetList(ProductListModel listModel)
        {
            return GetProductMaterialQuery()
                .GroupJoin(_materialAction.GetMaterialQuery(),
                    pm => pm.MaterialId,
                    m => m.Id,
                    (p, m) => new {Product = p, Materials = m.DefaultIfEmpty()})
                .SelectMany(
                    sm =>
                        sm.Materials.Select(
                            s =>
                                new
                                {
                                    sm.Product.ProductId,
                                    sm.Product.ProductName,
                                    ProductMaterialNeeded = sm.Product.MaterialCount,
                                    MaterialCount = s.Count
                                }))
                .GroupBy(g => new {g.ProductId, g.ProductName})
                .Select(s => new ProductListAnswer
                {
                    Id = s.Key.ProductId,
                    Name = s.Key.ProductName,
                    Count = (decimal) ((int) s.Min(m => m.MaterialCount/m.ProductMaterialNeeded))
                })
                .OrderBy(o => new {o.Name, o.Id})
                .Skip((listModel.PageNumber - 1)*listModel.PageSize)
                .Take(listModel.PageSize)
                .ToArray();

        }

        /// <summary>
        /// Получение деталей изделия
        /// </summary>
        /// <param name="id">Идентификатор изделия</param>
        /// <returns></returns>
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

        /// <summary>
        /// Обновление параметров изделия
        /// </summary>
        /// <param name="updateModel">модель данных для обновления</param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавление изделия
        /// </summary>
        /// <param name="addModel">модель данных для обновления</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление изделия
        /// </summary>
        /// <param name="id">Идентификатор изделия</param>
        public void Delete(Guid id)
        {
            using (var transaction = new TransactionScope())
            {
                _detailOfProduct.GetCollection()
                    .Where(w => w.ProductId.Equals(id))
                    .ToList()
                    .ForEach(f => _detailOfProduct.Delete(f.ProductId, f.DetailId));

                _product.Delete(id);
                transaction.Complete();
            }
        }

        /// <summary>
        /// Производство продукта
        /// </summary>
        /// <param name="produceModel">модель данных для произвоства</param>
        /// <returns>Результат. true=== успешно</returns>
        public bool Produce(ProduceModel produceModel)
        {
            if(produceModel.ProductCount<=0)
                throw  new Exception("Количество должно быть положительным");

            using (var transaction = new TransactionScope())
            {
                var productMaterial = GetProductMaterialQuery()
                    .Where(w => w.ProductId.Equals(produceModel.ProductId))
                    .GroupJoin(_materialAction.GetMaterialQuery(),
                        pm => pm.MaterialId,
                        m => m.Id,
                        (p, m) => new { Product = p, Materials = m.DefaultIfEmpty() })
                    .SelectMany(
                        sm =>
                            sm.Materials.Select(
                                s =>
                                    new
                                    {
                                        sm.Product.ProductId,
                                        ProductMaterialNeeded = sm.Product.MaterialCount,
                                        MaterialId = s.Id,
                                        MaterialCount = s.Count,
                                        MaterialName = s.Name
                                    }))
                    .GroupBy(g => new { g.ProductId, g.MaterialId, g.MaterialName })
                    .Select(s => new {
                        s.Key.ProductId, s.Key.MaterialId, s.Key.MaterialName,
                        Count = s.Sum(m => m.MaterialCount) - s.Sum(m => m.ProductMaterialNeeded) * produceModel.ProductCount,
                        CountForProduce = s.Sum(m => m.ProductMaterialNeeded) * produceModel.ProductCount
                    }).ToList();

                if (productMaterial.Any(a => a.Count < 0))
                {
                    var builder = new StringBuilder();
                    builder.Append("Не хватает материалов:");
                    foreach (var material in productMaterial.Where(w=>w.Count<0))
                    {
                        builder.Append("\n");
                        builder.Append(material.MaterialName);
                    }

                    transaction.Dispose();

                    throw new Exception(builder.ToString());
                    
                }

                productMaterial.ForEach(f=>_materialAction.DecreaseCount(f.MaterialId, f.CountForProduce));

                transaction.Complete();
            }

            return true;
        }

    }
}