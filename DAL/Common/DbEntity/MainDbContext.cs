using System.Configuration;
using System.Data.Entity;
using DAL.Common.DbInterface;
using DAL.Entity;

namespace DAL.Common.DbEntity
{
    /// <summary>
    /// Класс контекста БД
    /// </summary>
    public class MainDbContext : DbContext, IDbContext
    {
        /// <summary>
        /// DbSet Материалы
        /// </summary>
        public IDbSet<Material> Materials { get; set; }
        public IDbSet<MaterialOperation> MaterialOperations { get; set; }
        public IDbSet<MaterialOfDetail> MaterialsOfDetail { get; set; }
        public IDbSet<Detail> Details { get; set; }
        public IDbSet<DetailOfProduct> DetailsOfProduct { get; set; }
        public IDbSet<Product> Products { get; set; }



        public MainDbContext() : base(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString)
        {
            Database.SetInitializer<MainDbContext>(null);
        }

        /// <summary>
        /// Конфигурация маппига классов на объектв БД
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Material.MaterialConfiguration());
            modelBuilder.Configurations.Add(new MaterialOperation.MaterialOperationConfiguration());
            modelBuilder.Configurations.Add(new Detail.DetailConfiguration());
            modelBuilder.Configurations.Add(new Product.ProductConfiguration());
            modelBuilder.Configurations.Add(new DetailOfProduct.DetailOfProductConfiguration());
            modelBuilder.Configurations.Add(new MaterialOfDetail.MaterialOfDetailConfiguration());
        }
    }
}
