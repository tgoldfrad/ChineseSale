using ChineseSale.Entities;
using ChineseSale.Servers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailesController : ControllerBase
    {
        static readonly OrderDetailesServer orderDetailesServer = new OrderDetailesServer();

        // GET: api/<OrderDetailesController>
        [HttpGet]
        public ActionResult<List<OrderDetailes>> Get()
        {
            List<OrderDetailes> res = orderDetailesServer.GetOrderDetailes();
            return res;
        }

        // GET api/<OrderDetailesController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDetailes> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            OrderDetailes o = orderDetailesServer.GetOrderDetailesById(id);
            if(o != null)
                return o;
            return NotFound();
        }

        // POST api/<OrderDetailesController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] OrderDetailes orderDetailes)
        {
            orderDetailesServer.AddOrderDetailes(orderDetailes);
            return true;
        }

        // PUT api/<OrderDetailesController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] OrderDetailes orderDetailes)
        {
            if (id <= 0)
                return BadRequest();
            bool f = orderDetailesServer.UpdateOrderDetailes(id, orderDetailes);
            if (f)
                return true;
            return NotFound();
        }

        // DELETE api/<OrderDetailesController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = orderDetailesServer.DeleteOrderDetailes(id);
            if (f)
                return true;
            return NotFound();
        }
    }
}
