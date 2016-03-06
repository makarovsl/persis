using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Common.Entity;

namespace DAL.Entity
{
    public class Product : IEntity
    {
        /// <summary>
        /// Идентификатор изделия
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование изделия
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Связаные с изделием детали, не null только при применении инклуд методов
        /// </summary>
        public virtual ICollection<DetailOfProduct> DetailsOfProduct { get; set; }

        internal class ProductConfiguration : EntityTypeConfiguration<Product>
        {
            public ProductConfiguration()
            {
                ToTable("td_product", "dbo");
                Property(d => d.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
                Property(d => d.Name).HasColumnName("name").IsUnicode(false).IsRequired();
                HasMany(p => p.DetailsOfProduct).WithRequired().HasForeignKey(p => p.ProductId);
            }
        }
    }
}