using EventSphere.PaymentService.Domain.Enums;
using EventSphere.PaymentService.Domain.ValueObjects;

namespace EventSphere.PaymentService.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public int OrderId { get; private set; }
        public Money Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? PaidAt { get; private set; }

        private Payment() { }

        public Payment(int orderId, Money amount)
        {
            if (amount is null || amount.Value <= 0)
                throw new Exception($"Tutar doğru girilmemiş {amount}");

            Id = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            Status = PaymentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void Success()
        {
            if (Status != PaymentStatus.Pending)
                throw new Exception("Sadece pending durumunda olan ödemeler işleme girebilir");

            Status = PaymentStatus.Completed;
            PaidAt = DateTime.UtcNow;
        }

        public void Fail(string reason)
        {
            if (Status != PaymentStatus.Pending)
                throw new Exception("Sadece pending durumunda olan ödemeler işleme girebilir");

            Status = PaymentStatus.Failed;
        }

        public bool IsPaid() => Status == PaymentStatus.Completed;
    }
}
