using System;
using System.Data.Entity;
using System.Linq;
using DAL.Common.DbEntity;
using DAL.Entity;

namespace DAL.EntityDb
{
    public class DetailDb : RemovableEntityDb<Detail>
    {
        public DetailDb(IDbContext context)
            : base(context, dbContext => dbContext.Details)
		{
        }

        public override Detail GetByIdWithInclude(Guid id)
        {
            return GetList(Context)
                .Include(i => i.MaterialsOfDetail)
                .SingleOrDefault(s => s.Id == id);
        }

        public override IQueryable<Detail> GetIncludedCollection()
        {
            return GetList(Context)
                .Where(w => !w.IsDeleted)
                .Include(i => i.MaterialsOfDetail);
        }

        public override IQueryable<Detail> GetIncludedAllCollection()
        {
            return GetList(Context)
                .Include(i => i.MaterialsOfDetail);
        }

        public override Detail OnUpdate(Detail oldData, Detail newData)
        {
            if (oldData == null || newData == null) return null;

            oldData.Name = newData.Name;

            return oldData;
        }
    }
}
