using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Common.Entity;

namespace DAL.Entity
{
    /// <summary>
    /// Класс-сущность "Деталь"
    /// </summary>
    public class Detail : IRemovableEntity
    {
        /// <summary>
        /// Идентификатор детали
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование детали
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Признак логического удаления
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Связаные с деталью материалы, не null только при применении инклуд методов
        /// </summary>
        public virtual ICollection<MaterialOfDetail> MaterialsOfDetail { get; set; }

        internal class DetailConfiguration : EntityTypeConfiguration<Detail>
        {
            public DetailConfiguration()
            {
                ToTable("td_detail", "dbo");
                Property(d => d.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
                Property(d => d.Name).HasColumnName("name").IsUnicode(false).IsRequired();
                Property(d => d.IsDeleted).HasColumnName("is_deleted").IsRequired();
                HasMany(p => p.MaterialsOfDetail).WithRequired().HasForeignKey(p => p.DetailId);
            }
        }
    }
}