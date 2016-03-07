using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Common.DbEntity;

namespace DAL.Common.DbInterface
{
    public abstract class M2MEntityDb<T> : IM2MEntityDb<T> where T: class
    {
        protected readonly Func<IDbContext, IDbSet<T>> GetList;

        /// <summary>
        /// Контекст работы с БД
        /// </summary>
        public IDbContext Context { get; }
        protected M2MEntityDb(IDbContext context, Func<IDbContext, IDbSet<T>> list)
        {
            Context = context;
            GetList = list;
        }

        /// <summary>
        /// Полученеи списка объктов
        /// </summary>
        /// <returns>Список объектов, IQueryable</returns>
        public virtual IQueryable<T> GetCollection()
        {
            return GetList(Context);
        }

        /// <summary>
        /// Получение списка объектов с джойном со связными сущностями. Для реализации в конечном классе.
        /// </summary>
        /// <returns>Список объектов, IQueryable</returns>
        public abstract IQueryable<T> GetIncludedCollection();

        /// <summary>
        /// Удаление объекта в БД
        /// </summary>
        /// <param name="idOwner">Идентфикатор базовой сущности</param>
        /// <param name="idMany">Идентификатор свзяной сущности</param>
        public abstract void Delete(Guid idOwner, Guid idMany);

        /// <summary>
        /// Merge данных
        /// </summary>
        /// <param name="entity">Сущность</param>
        public void Upsert(T entity)
        {
            GetList(Context).AddOrUpdate(entity);
            Context.SaveChanges();
        }


    }
}