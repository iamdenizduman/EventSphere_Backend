using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.StockService.Entity.Dtos
{
    public class UpdateStockDto
    {
        public string Id { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int SoldQuantity { get; set; }
    }
}
