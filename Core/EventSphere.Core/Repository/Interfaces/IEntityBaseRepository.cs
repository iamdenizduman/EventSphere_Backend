using EventSphere.Core.Entity.Interfaces;

namespace EventSphere.Core.Repository.Interfaces
{
    public interface IEntityBaseRepository<T>
        where T : class, IEntity
    {

    }
}
