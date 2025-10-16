using System.Linq.Expressions;

namespace Pedidos.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        void Update(T entity);
        void Remove(T entity);

        Task<T?> Find(Guid id);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>>? filter = null,
                               string? includeProperties = null,
                               bool isTracking = true);

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = true,
                                   params Expression<Func<T, object>>[] includes);
    }
}
