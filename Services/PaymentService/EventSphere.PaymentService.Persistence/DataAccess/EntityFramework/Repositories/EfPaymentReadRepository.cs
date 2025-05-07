using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.PaymentService.Application.Interfaces.Repositories;
using EventSphere.PaymentService.Domain.Entities;
using EventSphere.PaymentService.Persistence.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace EventSphere.PaymentService.Persistence.DataAccess.EntityFramework.Repositories
{
    public class EfPaymentReadRepository : EfEntityReadRepository<Payment>, IPaymentReadRepository
    {
        public EfPaymentReadRepository(PaymentServiceDbContext context) : base(context)
        {
        }
    }
}
