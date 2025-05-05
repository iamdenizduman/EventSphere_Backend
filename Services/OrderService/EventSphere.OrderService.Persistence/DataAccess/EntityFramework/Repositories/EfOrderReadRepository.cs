using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.OrderService.Application.Interfaces.Repositories;
using EventSphere.OrderService.Domain.Entities;
using EventSphere.OrderService.Persistence.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.OrderService.Persistence.DataAccess.EntityFramework.Repositories
{
    public class EfOrderReadRepository : EfEntityReadRepository<Order>, IOrderReadRepository
    {
        public EfOrderReadRepository(OrderServiceDbContext context) : base(context)
        {
        }
    }
}
