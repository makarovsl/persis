using System;
using System.Data.Entity;
using System.Linq;
using DAL.Common.DbEntity;
using DAL.Common.DbInterface;
using DAL.Entity;

namespace DAL.EntityDb
{
    public class ProductDb : EntityDb<Product>
    {
        public ProductDb(IDbContext context)
            : base(context, dbContext => dbContext.Products)
		{
        }

        public override Product GetByIdWithInclude(Guid id)
        {
            return GetList(Context)
                .Include(i => i.DetailsOfProduct)
                .SingleOrDefault(s => s.Id == id);
        }

        public override IQueryable<Product> GetIncludedCollection()
        {
            return GetList(Context)
                .Include(i => i.DetailsOfProduct);
        }

        public override Product OnUpdate(Product oldData, Product newData)
        {
            if (oldData == null || newData == null) return null;

            oldData.Name = newData.Name;

            return oldData;
        }
    }
}