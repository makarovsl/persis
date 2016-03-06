using System;
using System.Data.Entity;
using System.Linq;
using DAL.Common.DbEntity;
using DAL.Entity;

namespace DAL.EntityDb
{
    /// <summary>
    /// Реализация работы с БД сущности "Жвижение материалов"
    /// </summary>
    public class MaterialOperationDb : EntityDb<MaterialOperation>
    {
        public MaterialOperationDb(IDbContext context)
            : base(context, dbContext => dbContext.MaterialOperations)
        {
        }

        public override MaterialOperation GetByIdWithInclude(Guid id)
        {
            return GetList(Context)
                .Include(i => i.Material)
                .SingleOrDefault(s => s.Id == id);
        }

        public override IQueryable<MaterialOperation> GetIncludedCollection()
        {
            return GetList(Context)
                .Include(i => i.Material);
        }

        public override MaterialOperation OnUpdate(MaterialOperation oldData, MaterialOperation newData)
        {
            throw new NotImplementedException();
        }
    }
}
