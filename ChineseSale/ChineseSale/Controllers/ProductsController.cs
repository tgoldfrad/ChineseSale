using ChineseSale.Entities;
using ChineseSale.Servers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static readonly ProductsServer productsServer = new ProductsServer();

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<List<Products>> Get()
        {
            List<Products> res = productsServer.GetProducts();
            return res;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Products> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Products p = productsServer.GetProductsById(id);
            if(p == null)
                return NotFound();
            return p;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Products product)
        {

            productsServer.AddProducts(product);
            return true;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Products product)
        {
            if (id <= 0)
                return BadRequest();
            bool f = productsServer.UpdateProducts(id, product);
            if(f)
            {
                return true;
            }
            return NotFound();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = productsServer.DeleteProducts(id);
            if (f)
            {
                return true;
            }
            return NotFound();

        }
    }
}
