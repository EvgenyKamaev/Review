using System.Linq;

namespace Review.Infrastructure.Data.Interfaces
{
    public interface IRepository<T> where T: BaseDomain
    {
        IQueryable<T> Table { get; }
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
