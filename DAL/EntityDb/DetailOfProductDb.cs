using System;
using System.Data.Entity;
using System.Linq;
using DAL.Common.DbEntity;
using DAL.Entity;

namespace DAL.EntityDb
{
    public class DetailOfProductDb : EntityDb<DetailOfProduct>
    {
        public DetailOfProductDb(IDbContext context)
            : base(context, dbContext => dbContext.DetailsOfProduct)
		{
        }

        public override DetailOfProduct GetByIdWithInclude(Guid id)
        {
            return GetList(Context)
                .Include(i => i.Product)
                .Include(i => i.Detail)
                .SingleOrDefault(s => s.Id == id);
        }

        public override IQueryable<DetailOfProduct> GetIncludedCollection()
        {
            return GetList(Context)
                .Include(i => i.Product)
                .Include(i => i.Detail);
        }

        public override DetailOfProduct OnUpdate(DetailOfProduct oldData, DetailOfProduct newData)
        {
            throw new NotImplementedException();
        }
    }
}