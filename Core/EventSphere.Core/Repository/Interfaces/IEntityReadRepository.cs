using EventSphere.Core.Entity.Interfaces;
using System.Linq.Expressions;

namespace EventSphere.Core.Repository.Interfaces
{
    public interface IEntityReadRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntity
    {
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
