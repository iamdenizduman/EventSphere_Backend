using EventSphere.Core.Result;
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
        public Task<DataResult<CreatePaymentResponse>> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
