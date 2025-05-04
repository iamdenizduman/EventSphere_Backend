namespace EventSphere.StockService.Entity.Dtos
{
    public class AddStockHistoryDto
    {
        public string StockId { get; set; }
        public string Action { get; set; }
        public int QuantityChanged { get; set; }
    }
}
