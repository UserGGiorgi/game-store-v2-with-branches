namespace GameStore.Application.Dtos.Order
{
    public class OrderDetailDto
    {
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int? Discount { get; set; }
    }

}
