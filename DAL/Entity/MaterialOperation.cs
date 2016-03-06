
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Common.Entity;

namespace DAL.Entity
{
    /// <summary>
    /// Класс-сущность "Движение материалов"
    /// </summary>
    public class MaterialOperation : IEntity
    {
        /// <summary>
        /// Идентификатор операции
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор материала
        /// </summary>
        public Guid MaterialId { get; set; }

        /// <summary>
        /// Материал, не null только при применении инклуд методов
        /// </summary>
        public virtual Material Material { get; set; }

        /// <summary>
        /// Количество материалов по операциям
        /// </summary>
        public decimal Count { get; set; }

        /// <summary>
        /// Дата-время операции, время сервера БД
        /// </summary>
        public DateTime OperationDate { get; private set; }

        /// <summary>
        /// Реализация мапинга на таблицу БД
        /// </summary>
        internal class MaterialOperationConfiguration : EntityTypeConfiguration<MaterialOperation>
        {
            public MaterialOperationConfiguration()
            {
                //todo Привести к единственному числу
                ToTable("t_material_operations", "dbo");
                Property(d => d.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
                Property(d => d.MaterialId).HasColumnName("material_id").IsRequired();
                Property(d => d.Count).HasColumnName("count").IsRequired();
                Property(d => d.OperationDate).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).HasColumnName("operation_date").IsRequired();
            }
        }

    }
}
