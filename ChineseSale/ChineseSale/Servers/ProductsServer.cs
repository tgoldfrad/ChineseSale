using ChineseSale.Entities;

namespace ChineseSale.Servers
{
    public class ProductsServer
    {
        //public List<Products> products = new List<Products>()
        //{
        //new Products() {ProductId = 1,ProductName="computer",Description="i7",DonatedBy="dan store" ,NumWinners=2,ProductPrice=50},
        //new Products() {ProductId = 2,ProductName="oven",Description="buildin",DonatedBy="mystore" ,NumWinners=1,ProductPrice=40}
        //};

        public List<Products> GetProducts()
        {
            return DataContextManager.DataContext.ProductsList;
        }
        public Products GetProductsById(int id)
        {
            return DataContextManager.DataContext.ProductsList.Find(x => x.ProductId == id);
        }
        public bool AddProducts(Products p)
        {
            DataContextManager.DataContext.ProductsList.Add(p);
            return true;
        }
        public bool UpdateProducts(int id,Products p)
        {
            int index = DataContextManager.DataContext.ProductsList.FindIndex(x => x.ProductId == id);
            if(index != -1)
            {
                DataContextManager.DataContext.ProductsList[index]=p;
                return true;
            }
            return false;
        }
        public bool DeleteProducts(int id)
        {
            Products product = GetProductsById(id);
            if(product != null)
            {
                DataContextManager.DataContext.ProductsList.Remove(product);
                return true;
            }
            return false;
        }
    }
}
