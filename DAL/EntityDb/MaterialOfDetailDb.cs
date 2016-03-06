using System;
using System.Data.Entity;
using System.Linq;
using DAL.Common.DbEntity;
using DAL.Entity;

namespace DAL.EntityDb
{
    public class MaterialOfDetailDb : EntityDb<MaterialOfDetail>
    {
        public MaterialOfDetailDb(IDbContext context)
            : base(context, dbContext => dbContext.MaterialsOfDetail)
		{
        }

        public override MaterialOfDetail GetByIdWithInclude(Guid id)
        {
            return GetList(Context)
                .Include(i => i.Material)
                .Include(i => i.Detail)
                .SingleOrDefault(s => s.Id == id);
        }

        public override IQueryable<MaterialOfDetail> GetIncludedCollection()
        {
            return GetList(Context)
                .Include(i => i.Material)
                .Include(i => i.Detail);
        }

        public override MaterialOfDetail OnUpdate(MaterialOfDetail oldData, MaterialOfDetail newData)
        {
            throw new NotImplementedException();
        }
    }
}