using ChineseSale.Core.Entities;
using ChineseSale.Core.IServices;
using ChineseSale.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _productService.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {

            if (id <= 0)
                return BadRequest();
            Product product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Product product)
        {
            if (_productService.Add(product) != null)
                return true;
            return BadRequest();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Product product)
        {
            if (id <= 0)
                return BadRequest();
            bool f = _productService.Update(id, product);
            if (f)
            {
                return true;
            }
            return NotFound();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = _productService.Delete(id);
            if (f)
            {
                return true;
            }
            return NotFound();
        }
    }
}
