using ChineseSale.Entities;
using ChineseSale.Servers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        static readonly OrdersServer ordersServer = new OrdersServer();
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<List<Orders>> Get()
        {
            List<Orders> res = ordersServer.GetOrders();
            return Ok(res);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Orders> Get(int id)
        {
            Orders order = ordersServer.GetOrdersById(id);
            if(order != null)
                return Ok(order);
            return NotFound();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post([FromBody] Orders order)
        {
            ordersServer.PostOrders(order);
            return Ok();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Orders order)
        {
            bool f = ordersServer.PutOrders(id,order);
            if(f)
                return Ok();
            return NotFound();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool f = ordersServer.DeleteOrders(id);
            if (f)
                return Ok();
            return NotFound();
        }
    }
}
