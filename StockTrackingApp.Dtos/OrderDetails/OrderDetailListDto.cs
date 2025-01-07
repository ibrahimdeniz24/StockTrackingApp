namespace StockTrackingApp.Dtos.OrderDetails
{
    public class OrderDetailListDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public Guid WarehouseId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
