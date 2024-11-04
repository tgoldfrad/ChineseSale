namespace ChineseSale.Entities
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }
        public int ProductPrice { get; set; }
        public int NumWinners { get; set; }
        public string DonatedBy { get; set; }

    }
}
