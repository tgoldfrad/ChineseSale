using ChineseSale.Core.Entities;
using ChineseSale.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Data.Repositories
{
    public class ProductRepository:IProductRepository
    {
        readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Product> GetAll()
        {
            return _dataContext.ProductsList.ToList();
        }
        public Product GetById(int id)
        {
            return _dataContext.ProductsList.Where(p => p.ProductId == id).FirstOrDefault();
        }
        public Product Add(Product product)
        {
            try
            {
                _dataContext.ProductsList.Add(product);
                _dataContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, Product product)
        {
            var productToUpdate = _dataContext.ProductsList.Find(id);
            if(productToUpdate == null)
                return false;
            
            ///////---------האם יש דרך בלי השמה של מה שקיים-----------
            productToUpdate.ProductName = !String.IsNullOrEmpty(product.ProductName) ? product.ProductName : productToUpdate.ProductName;
            productToUpdate.Description = !String.IsNullOrEmpty(product.Description) ? product.Description : productToUpdate.Description;
            productToUpdate.ProductPrice = product.ProductPrice > 0 ? product.ProductPrice : productToUpdate.ProductPrice;
            productToUpdate.NumWinners = product.NumWinners > 0 ? product.NumWinners: productToUpdate.NumWinners;
            productToUpdate.DonatedBy = !String.IsNullOrEmpty(product.DonatedBy) ? product.DonatedBy : productToUpdate.DonatedBy;
            //return _dataContext.SaveChange(dataProduct);
            return true;

        }
        public bool Delete(int id)
        {
            var productToDelete = GetById(id);//find by id...
            if (productToDelete == null)
                return false;
            _dataContext.ProductsList.Remove(productToDelete);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
