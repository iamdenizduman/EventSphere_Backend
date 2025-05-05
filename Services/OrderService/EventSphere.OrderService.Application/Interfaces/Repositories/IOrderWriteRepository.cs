using EventSphere.Core.Repository.Interfaces;
using EventSphere.OrderService.Domain.Entities;

namespace EventSphere.OrderService.Application.Interfaces.Repositories
{
    public interface IOrderWriteRepository : IEntityWriteRepository<Order>
    {
    }
}
