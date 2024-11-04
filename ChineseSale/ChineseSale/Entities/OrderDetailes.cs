namespace ChineseSale.Entities
{
    public class OrderDetailes
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int amount { get; set; }
        public int finalPayment { get; set; }
    }
}
