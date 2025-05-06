namespace EventSphere.OrderService.Domain.Enums
{
    public enum OrderStatus
    {
        Pending,           // Sipariş oluşturuldu, henüz işlenmeye başlanmadı
        StockReserved,     // Stok başarıyla düşüldü, ödeme aşamasına geçilecek
        PaymentProcessing, // Ödeme işlemi başlatıldı
        Completed,         // Her şey başarılı, sipariş tamamlandı
        Failed,            // Herhangi bir adımda başarısızlık oldu
        Cancelled          // Kullanıcı tarafından iptal edildi
    }
}
