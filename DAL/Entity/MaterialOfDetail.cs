using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Common.Entity;

namespace DAL.Entity
{
    /// <summary>
    /// m2m связь деталь-материал
    /// </summary>
    public class MaterialOfDetail 
    {

        /// <summary>
        /// Идентификатор материала
        /// </summary>
        public Guid MaterialId { get; set; }

        /// <summary>
        /// Идентификатор детали
        /// </summary>
        public Guid DetailId { get; set; }

        /// <summary>
        /// Количество материалов еобходимы для производства детали
        /// </summary>
        public decimal MaterialCount { get; set; }

        /// <summary>
        /// Материал, не null только при применении инклуд методов
        /// </summary>
        public virtual Material Material { get; set; }

        /// <summary>
        /// Деталь, не null только при применении инклуд методов
        /// </summary>
        public virtual Detail Detail { get; set; }

        internal class MaterialOfDetailConfiguration : EntityTypeConfiguration<MaterialOfDetail>
        {
            public MaterialOfDetailConfiguration()
            {
                ToTable("t_material_detail", "dbo");
                HasKey(k => new {k.MaterialId, k.DetailId});
                Property(d => d.MaterialId).HasColumnName("material_id").IsRequired();
                Property(d => d.DetailId).HasColumnName("detail_id").IsRequired();
                Property(d => d.MaterialCount).HasColumnName("material_count").IsRequired();


                HasRequired(p => p.Detail).WithMany().HasForeignKey(p => p.DetailId);
                HasRequired(p => p.Material).WithMany().HasForeignKey(p => p.MaterialId);

            }
        }
    }
}