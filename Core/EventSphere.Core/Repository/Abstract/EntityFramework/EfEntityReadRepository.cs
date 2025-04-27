using EventSphere.Core.Entity.Interfaces;
using EventSphere.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventSphere.Core.Repository.Abstract.EntityFramework
{
    public abstract class EfEntityReadRepository<T>(DbContext context) : IEntityReadRepository<T>, IEntityBaseRepository<T>
        where T : class, IEntity, new()
    {
        private readonly DbContext _context = context;

        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
                return await _context.Set<T>().AnyAsync(predicate);

            return await _context.Set<T>().AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
                return await _context.Set<T>().CountAsync(predicate);

            return await _context.Set<T>().CountAsync();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
                query = query.Where(predicate);
            
            if (includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.SingleOrDefaultAsync();
        }
    }
}
