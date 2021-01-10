using System.Data.Entity;

namespace Review.Infrastructure.Data.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseDomain;

        int SaveChanges();
    }
}
