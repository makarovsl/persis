using System;
using System.Data.Entity;
using System.Linq;
using DAL.Common.DbEntity;
using DAL.Common.DbInterface;
using DAL.Entity;

namespace DAL.EntityDb
{
    /// <summary>
    /// Реализация работы с БД сущности Материал
    /// </summary>
    public class MaterialDb : RemovableEntityDb<Material>
    {
        public MaterialDb(IDbContext context)
            : base(context, dbContext => dbContext.Materials)
		{
        }

        public override Material GetByIdWithInclude(Guid id)
        {
            return GetList(Context)
                .Include(i => i.MaterialOperations)
                .SingleOrDefault(s => s.Id == id);
        }

        public override IQueryable<Material> GetIncludedCollection()
        {
            return GetList(Context)
                .Where(w=>!w.IsDeleted)
                .Include(i=>i.MaterialOperations);
        }

        public override IQueryable<Material> GetIncludedAllCollection()
        {
            return GetList(Context)
                .Include(i => i.MaterialOperations);
        }

        public override Material OnUpdate(Material oldData, Material newData)
        {
            if (oldData == null || newData == null) return null;

            oldData.Name = newData.Name;

            return oldData;
        }
    }
}
