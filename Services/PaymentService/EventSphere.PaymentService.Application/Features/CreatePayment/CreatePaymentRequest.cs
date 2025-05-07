using EventSphere.Core.Result;
using MediatR;

namespace EventSphere.PaymentService.Application.Features.CreatePayment
{
    public class CreatePaymentRequest : IRequest<DataResult<CreatePaymentResponse>>
    {
        public int BuyerId { get; set; }
        public int EventId { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
