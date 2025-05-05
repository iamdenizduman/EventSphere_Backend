using EventSphere.Core.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.OrderService.Application.Features.Orders.CreateOrder
{
    public class CreateOrderRequest : IRequest<DataResult<CreateOrderResponse>>
    {
        public int BuyerId { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }
    }
}
