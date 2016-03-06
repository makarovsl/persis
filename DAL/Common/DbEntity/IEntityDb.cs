using System;
using System.Linq;
using DAL.Common.Entity;

namespace DAL.Common.DbEntity
{
    /// <summary>
    /// Инеьерфейс для реализации работы сущности с БД
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityDb<T> where T : class, IEntity
    {
        IDbContext Context { get; }
        T GetById(Guid id);
        T GetByIdWithInclude(Guid id);
        IQueryable<T> GetCollection();
        IQueryable<T> GetIncludedCollection();
        Guid Insert(T data);
        void Update(T data);
        void Delete(Guid id);
    }
}