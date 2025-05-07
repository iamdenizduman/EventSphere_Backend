using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.PaymentService.Infrastructure.Configurations
{
    public class IyzicoPaymentSettings
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public string BaseUrl { get; set; }
    }
}
