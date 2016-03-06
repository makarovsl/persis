using System;

namespace DAL.Common.Entity
{
    /// <summary>
    /// Интерфейс классов сущностей БД с первичным ключом
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
