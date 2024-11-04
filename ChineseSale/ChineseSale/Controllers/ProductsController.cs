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
            return Ok(res);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Products> Get(int id)
        {
            Products p = productsServer.GetProductsById(id);
            if(p == null)
                return NotFound();
            return Ok(p);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post([FromBody] Products product)
        {
            productsServer.PostProducts(product);
            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Products product)
        {
            bool f = productsServer.PutProducts(id, product);
            if(f)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool f = productsServer.DeleteProducts(id);
            if (f)
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
