using System.Data.Entity;
using System.Reflection;
using Review.Infrastructure.Data.Interfaces;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using System;

namespace Review.Infrastructure.Data
{
    public class ReviewContext : DbContext, IDbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                                type.BaseType != null &&
                                type.BaseType.IsGenericType &&
                                type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (dynamic configurationInstance in typesToRegister.Select(Activator.CreateInstance))
                modelBuilder.Configurations.Add(configurationInstance);

            base.OnModelCreating(modelBuilder);
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseDomain
            => base.Set<TEntity>();
    }
}
