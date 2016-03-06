using System.Linq;
using DAL.Common.Entity;

namespace DAL.Common.DbEntity
{
    /// <summary>
    /// Интерфейс для реализации работы логически удаляемой сущности с БД
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRemovableEntityDb<T> : IEntityDb<T> where T : class, IRemovableEntity
    {
        IQueryable<T> GetAllCollection();
        IQueryable<T> GetIncludedAllCollection();
    }
}