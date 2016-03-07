using System;
using System.Data.Entity;
using System.Linq;
using DAL.Common.DbInterface;
using DAL.Common.Entity;

namespace DAL.Common.DbEntity
{
    /// <summary>
    /// Абстрактный класс реализующий работу с данными БД
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityDb<T> : IEntityDb<T>
        where T : class, IEntity
    {
        protected readonly Func<IDbContext, IDbSet<T>> GetList;

        protected EntityDb(IDbContext context, Func<IDbContext, IDbSet<T>> list)
        {
            Context = context;
            GetList = list;
        }

        /// <summary>
        /// Контекст работы с БД
        /// </summary>
        public IDbContext Context { get; }

        /// <summary>
        /// Получение объекта по первичному ключу
        /// </summary>
        /// <param name="id">Первичный ключ</param>
        /// <returns>Найденный объект/ Null</returns>
        public T GetById(Guid id)
        {
            return GetList(Context).SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение объекта с джойном со связными сущностями. Для реализации в конечном классе.
        /// </summary>
        /// <param name="id">Первичный ключ</param>
        /// <returns></returns>
        public abstract T GetByIdWithInclude(Guid id);

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
        /// Добавление объекта в БД
        /// </summary>
        /// <param name="data">Сущность</param>
        /// <returns>Первичный ключ объекта</returns>
        public Guid Insert(T data)
        {
            GetList(Context).Add(data);
            Context.SaveChanges();
            return data.Id;
        }

        /// <summary>
        /// Update объекта в БД
        /// </summary>
        /// <param name="data">Сущность</param>
        public void Update(T data)
        {
            if (data == null) return;
            T item = GetById(data.Id);
            if (OnUpdate(item, data) != null)
                Context.SaveChanges();
        }
        /// <summary>
        /// Реализация обновления полей. Для реализации в конечном классе.
        /// </summary>
        /// <param name="oldData">Старок значение объекта</param>
        /// <param name="newData">Новое значение объекта</param>
        /// <returns>сущность</returns>
        public abstract T OnUpdate(T oldData, T newData);

        /// <summary>
        /// Удаление объекта в БД
        /// </summary>
        /// <param name="id">Первичный ключ</param>
        public virtual void Delete(Guid id)
        {
            T data = GetById(id);
            if (data == null) return;
            GetList(Context).Remove(data);
            Context.SaveChanges();
        }
    }
}