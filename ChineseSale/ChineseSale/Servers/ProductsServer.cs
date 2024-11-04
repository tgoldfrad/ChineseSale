using ChineseSale.Entities;

namespace ChineseSale.Servers
{
    public class ProductsServer
    {
        public List<Products> products = new List<Products>()
        {
        new Products() {ProductId = 1,ProductName="computer",Description="i7",DonatedBy="dan store" ,NumWinners=2,ProductPrice=50},
        new Products() {ProductId = 2,ProductName="oven",Description="buildin",DonatedBy="mystore" ,NumWinners=1,ProductPrice=40}
        };

        public List<Products> GetProducts()
        {
            return products;
        }
        public Products GetProductsById(int id)
        {
            return products.Find(x => x.ProductId == id);
        }
        public bool PostProducts(Products p)
        {
            products.Add(p);
            return true;
        }
        public bool PutProducts(int id,Products p)
        {
            int index = products.FindIndex(x => x.ProductId == id);
            if(index != -1)
            {
                products[index]=p;
                return true;
            }
            return false;
        }
        public bool DeleteProducts(int id)
        {
            Products product = products.Find(x => x.ProductId == id);
            if(product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }
    }
}
