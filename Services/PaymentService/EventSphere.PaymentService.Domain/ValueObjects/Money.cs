namespace EventSphere.PaymentService.Domain.ValueObjects
{
    public class Money
    {
        public decimal Value { get; }
        public string Currency { get; }

        private Money() { }

        public Money(decimal value, string currency)
        {
            if (value <= 0)
                throw new ArgumentException("Tutar pozitif olmalı", nameof(value));

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Para birimi gereklidir", nameof(currency));

            Value = value;
            Currency = currency.ToUpperInvariant();
        }

        public override bool Equals(object obj)
        {
            if (obj is not Money other)
                return false;

            return Value == other.Value && Currency == other.Currency;
        }

        public override int GetHashCode() => HashCode.Combine(Value, Currency);
    }
}
