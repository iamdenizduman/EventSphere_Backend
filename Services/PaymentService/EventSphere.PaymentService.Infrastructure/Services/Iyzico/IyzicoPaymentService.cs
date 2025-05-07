using EventSphere.PaymentService.Application.Interfaces.Services.Iyzico;
using EventSphere.PaymentService.Infrastructure.Configurations;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.Extensions.Options;

namespace EventSphere.PaymentService.Infrastructure.Services.Iyzico
{
    public class IyzicoPaymentService : IIyzicoPaymentService
    {
        private readonly IyzicoPaymentSettings _settings;
        public IyzicoPaymentService(IOptions<IyzicoPaymentSettings> options)
        {
            _settings = options.Value;
        }

        public async Task CreatePayment()
        {
            var request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "100", 
                PaidPrice = "100",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };
            request.PaymentCard = new PaymentCard
            {
                CardHolderName = "Ahmet Yılmaz",
                CardNumber = "5528790000000008",
                ExpireMonth = "12",
                ExpireYear = "2030",
                Cvc = "123",
                RegisterCard = 0
            };
            Payment payment = await Payment.Create(request, new Iyzipay.Options { ApiKey = _settings.ApiKey, BaseUrl = _settings.BaseUrl, SecretKey = _settings.SecretKey});

            if (payment.Status == "success")
            {
                Console.WriteLine("Ödeme başarılı! PaymentId: " + payment.PaymentId);
            }
            else
            {
                Console.WriteLine("Hata: " + payment.ErrorMessage);
            }
        }
    }
}
