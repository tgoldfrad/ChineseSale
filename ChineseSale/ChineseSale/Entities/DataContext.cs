namespace ChineseSale.Entities
{
    public class DataContext
    {
        public List<Cities> CitiesList { get; set; }
        public List<Donors> DonorsList { get; set; }
        public List<OrderDetailes> OrderDetailesList { get; set; }
        public List<Orders> OrdersList { get; set; }
        public List<Products> ProductsList { get; set; }
        public DataContext()
        {
            CitiesList = new List<Cities>();
            DonorsList = new List<Donors>();
            OrderDetailesList = new List<OrderDetailes>();
            OrdersList = new List<Orders>();
            ProductsList = new List<Products>();
        }
    }
}
