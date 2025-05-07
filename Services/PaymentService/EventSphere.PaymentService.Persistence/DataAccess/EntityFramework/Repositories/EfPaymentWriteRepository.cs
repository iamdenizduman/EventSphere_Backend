using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.PaymentService.Application.Interfaces.Repositories;
using EventSphere.PaymentService.Domain.Entities;
using EventSphere.PaymentService.Persistence.DataAccess.EntityFramework.Context;

namespace EventSphere.PaymentService.Persistence.DataAccess.EntityFramework.Repositories
{
    public class EfPaymentWriteRepository : EfEntityWriteRepository<Payment>, IPaymentWriteRepository
    {
        public EfPaymentWriteRepository(PaymentServiceDbContext context) : base(context)
        {
        }
    }
}
