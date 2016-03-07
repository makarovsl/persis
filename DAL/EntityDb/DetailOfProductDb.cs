using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Common.DbEntity;
using DAL.Common.DbInterface;
using DAL.Entity;

namespace DAL.EntityDb
{
    public class DetailOfProductDb : M2MEntityDb<DetailOfProduct>
    {
        public DetailOfProductDb(IDbContext context)
            : base(context, dbContext => dbContext.DetailsOfProduct)
        {
        }



        public override IQueryable<DetailOfProduct> GetIncludedCollection()
        {
            return GetList(Context)
                .Include(i => i.Product)
                .Include(i => i.Detail);
        }

        public override void Delete(Guid productId, Guid detailId)
        {
            var item = GetList(Context).SingleOrDefault(w => w.ProductId.Equals(productId)
                                                             && w.DetailId.Equals(detailId));
            if (item == null)
                return;
            GetList(Context).Remove(item);
            Context.SaveChanges();
        }

    }
}