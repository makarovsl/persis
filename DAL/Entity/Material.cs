using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using DAL.Common.Entity;

namespace DAL.Entity
{
    /// <summary>
    /// Класс-сущность "Материалы"
    /// </summary>
    public class Material : IRemovableEntity
    {
        /// <summary>
        /// Идентификатор материала
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование материала
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Признак логического удаления
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Операции над материалом, не null только при применении инклуд методов
        /// </summary>
        public virtual ICollection<MaterialOperation> MaterialOperations { get; set; }

        /// <summary>
        /// Реализация мапинга на таблицу БД
        /// </summary>
        internal class MaterialConfiguration : EntityTypeConfiguration<Material>
        {
            public MaterialConfiguration()
            {
                ToTable("td_material", "dbo");
                Property(d => d.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
                Property(d => d.Name).HasColumnName("name").IsUnicode(false).IsRequired();
                Property(d => d.IsDeleted).HasColumnName("is_deleted").IsRequired();
                HasMany(p => p.MaterialOperations).WithRequired().HasForeignKey(p => p.MaterialId);
            }
        }
    }
}
