namespace EventSphere.PaymentService.Application.Features.CreatePayment
{
    public class CreatePaymentResponse
    {
        public bool IsPaymentSuccess { get; set; }
        public int OrderId { get; set; }
    }
}
