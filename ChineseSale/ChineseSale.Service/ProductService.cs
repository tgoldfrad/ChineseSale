using ChineseSale.Core.Entities;
using ChineseSale.Core.IRepositories;
using ChineseSale.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Service
{
    public class ProductService:IProductService
    {
            readonly IProductRepository _productRepository;

            public ProductService(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            
            public List<Product> GetAll()
            {
                var dataProduct = _productRepository.GetAll();
                if (dataProduct == null)
                    return null;
                return dataProduct.ToList();
            }
            public Product GetById(int id)
            {
                return _productRepository.GetById(id);
            }
            public Product Add(Product product)
            {
                if(product == null)
                    return null;
                return _productRepository.Add(product);
            }
            public bool Update(int id, Product product)
            {
                if (product == null)
                    return false;
                return _productRepository.Update(id, product);
            }
            public bool Delete(int id)
            {
                return _productRepository.Delete(id);
            }
            
        }
}
