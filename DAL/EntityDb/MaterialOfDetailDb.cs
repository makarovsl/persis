using System;
using System.Data.Entity;
using System.Linq;
using DAL.Common.DbEntity;
using DAL.Common.DbInterface;
using DAL.Entity;

namespace DAL.EntityDb
{
    public class MaterialOfDetailDb : M2MEntityDb<MaterialOfDetail>
    {
        public MaterialOfDetailDb(IDbContext context)
            : base(context, dbContext => dbContext.MaterialsOfDetail)
		{
        }

        public override IQueryable<MaterialOfDetail> GetIncludedCollection()
        {
            return GetList(Context)
                .Include(i => i.Material)
                .Include(i => i.Detail);
        }

        public override void Delete(Guid detailId, Guid materialId)
        {
            var item = GetList(Context).SingleOrDefault(w => w.MaterialId.Equals(materialId)
                                                             && w.DetailId.Equals(detailId));
            if (item == null)
                return;
            GetList(Context).Remove(item);
            Context.SaveChanges();
        }
    }
}