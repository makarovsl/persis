using System;
using System.Linq;
using DAL.Common.DbInterface;

namespace DAL.Common.DbEntity
{
    public interface IM2MEntityDb<T>
    {
        IDbContext Context { get; }
        IQueryable<T> GetCollection();
        IQueryable<T> GetIncludedCollection();
        void Delete(Guid ownerId, Guid manyId);
        void Upsert(T entity);
    }
}