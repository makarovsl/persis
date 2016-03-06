using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Entity;

namespace DAL.Common.DbEntity
{
    /// <summary>
    /// Интерфейс контекста работы с БД
    /// </summary>
    public interface IDbContext
    {

        IDbSet<Material> Materials { get; set; }
        IDbSet<MaterialOperation> MaterialOperations { get; set; }
        IDbSet<MaterialOfDetail> MaterialsOfDetail { get; set; }
        IDbSet<Detail> Details { get; set; }
        IDbSet<DetailOfProduct> DetailsOfProduct { get; set; }
        IDbSet<Product> Products { get; set; } 
        



        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbContextConfiguration Configuration { get; }
    }
}
