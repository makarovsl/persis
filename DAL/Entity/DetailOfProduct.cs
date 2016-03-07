using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Common.Entity;

namespace DAL.Entity
{
    /// <summary>
    /// m2m связь деталь-изделие
    /// </summary>
    public class DetailOfProduct
    {

        /// <summary>
        /// Идентификатор детали
        /// </summary>
        public Guid DetailId { get; set; }

        /// <summary>
        /// Идентификатор изделия
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Количество деталей еобходимы для производства изделия
        /// </summary>
        public decimal DetailCount { get; set; }

        /// <summary>
        /// Деталь, не null только при применении инклуд методов
        /// </summary>
        public virtual Detail Detail { get; set; }

        /// <summary>
        /// Изделие, не null только при применении инклуд методов
        /// </summary>
        public virtual Product Product { get; set; }

        internal class DetailOfProductConfiguration : EntityTypeConfiguration<DetailOfProduct>
        {
            public DetailOfProductConfiguration()
            {
                ToTable("t_detail_product", "dbo");
                HasKey(k => new {k.ProductId, k.DetailId});
                Property(d => d.ProductId).HasColumnName("product_id").IsRequired();
                Property(d => d.DetailId).HasColumnName("detail_id").IsRequired();
                Property(d => d.DetailCount).HasColumnName("detail_count").IsRequired();

                HasRequired(p => p.Detail).WithMany().HasForeignKey(p => p.DetailId);
                HasRequired(p => p.Product).WithMany().HasForeignKey(p => p.ProductId);

            }
        }

    }
}