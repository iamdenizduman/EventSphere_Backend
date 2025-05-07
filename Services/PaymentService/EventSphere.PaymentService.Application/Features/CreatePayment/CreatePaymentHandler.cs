using EventSphere.Core.Enums;
using EventSphere.Core.Repository.Interfaces;
using EventSphere.Core.Result;
using EventSphere.PaymentService.Application.Interfaces.Repositories;
using EventSphere.PaymentService.Application.Interfaces.Services.Iyzico;
using EventSphere.PaymentService.Domain.Entities;
using EventSphere.PaymentService.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.PaymentService.Application.Features.CreatePayment
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentRequest, DataResult<CreatePaymentResponse>>
    {
        private readonly IPaymentWriteRepository _paymentWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIyzicoPaymentService _iyzicoPaymentService;

        public CreatePaymentHandler(IPaymentWriteRepository paymentWriteRepository, IUnitOfWork unitOfWork, IIyzicoPaymentService iyzicoPaymentService)
        {
            _paymentWriteRepository = paymentWriteRepository;
            _unitOfWork = unitOfWork;
            _iyzicoPaymentService = iyzicoPaymentService;
        }

        public async Task<DataResult<CreatePaymentResponse>> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                Payment payment = new Payment(request.OrderId, new Money(request.TotalPrice, "TL"));
                await _paymentWriteRepository.AddAsync(payment);
                await _paymentWriteRepository.SaveChangesAsync();

                await _iyzicoPaymentService.CreatePayment();

                await _unitOfWork.CommitAsync();

                return new DataResult<CreatePaymentResponse>(new CreatePaymentResponse { IsPaymentSuccess = true, OrderId = request.OrderId }, ResultStatus.Success, "Ödeme başarıyla alındı.");
            }
            catch (Exception)
            {
                return new DataResult<CreatePaymentResponse>(null, ResultStatus.Error, "Ödeme başarısız.");
            }
        }
    }    
}
