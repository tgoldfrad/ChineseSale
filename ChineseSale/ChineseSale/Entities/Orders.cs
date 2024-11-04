namespace ChineseSale.Entities
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int DonorId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool PaymentIsOrdered { get; set; }
        public bool IsTaxReceipt { get; set; }
        public string NameReceipt { get; set; }
        public int OrderFinalPayment { get; set; }
        public string Remarks { get; set; }
    }
}
