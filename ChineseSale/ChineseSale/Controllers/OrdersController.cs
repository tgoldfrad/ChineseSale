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
            return res;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Orders> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Orders order = ordersServer.GetOrdersById(id);
            if(order != null)
                return order;
            return NotFound();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Orders order)
        {
            ordersServer.AddOrders(order);
            return true;
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Orders order)
        {
            if (id <= 0)
                return BadRequest();
            bool f = ordersServer.UpdateOrders(id,order);
            if(f)
                return true;
            return NotFound();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = ordersServer.DeleteOrders(id);
            if (f)
                return true;
            return NotFound();
        }
    }
}
