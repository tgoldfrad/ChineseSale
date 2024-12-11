using ChineseSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
        bool Update(int id, Product product);
        bool Delete(int id);
    }
}
