using EventSphere.OrderService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.OrderService.Persistence.DataAccess.EntityFramework.Context
{
    public class OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> opt) : DbContext(opt)
    {
        public DbSet<Order> Orders { get; set; }
    }
}
