using EventSphere.Core.Repository.Interfaces;
using EventSphere.PaymentService.Domain.Entities;

namespace EventSphere.PaymentService.Application.Interfaces.Repositories
{
    public interface IPaymentWriteRepository : IEntityWriteRepository<Payment>
    {
    }
}
