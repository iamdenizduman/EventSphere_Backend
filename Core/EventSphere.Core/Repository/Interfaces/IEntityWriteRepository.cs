using EventSphere.Core.Entity.Interfaces;

namespace EventSphere.Core.Repository.Interfaces
{
    public interface IEntityWriteRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntity, new()
    {
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }
}
