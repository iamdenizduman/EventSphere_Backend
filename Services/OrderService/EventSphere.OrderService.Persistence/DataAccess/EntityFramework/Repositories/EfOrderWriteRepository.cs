using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.OrderService.Application.Interfaces.Repositories;
using EventSphere.OrderService.Domain.Entities;
using EventSphere.OrderService.Persistence.DataAccess.EntityFramework.Context;

namespace EventSphere.OrderService.Persistence.DataAccess.EntityFramework.Repositories
{
    public class EfOrderWriteRepository : EfEntityWriteRepository<Order>, IOrderWriteRepository
    {
        public EfOrderWriteRepository(OrderServiceDbContext context) : base(context)
        {
        }
    }
}
