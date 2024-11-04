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
            return Ok(res);
        }

        // GET api/<OrderDetailesController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDetailes> Get(int id)
        {
            OrderDetailes o = orderDetailesServer.GetOrderDetailesById(id);
            if(o != null)
                return Ok(o);
            return NotFound();
        }

        // POST api/<OrderDetailesController>
        [HttpPost]
        public ActionResult Post([FromBody] OrderDetailes orderDetailes)
        {
            orderDetailesServer.PostOrderDetailes(orderDetailes);
            return Ok();
        }

        // PUT api/<OrderDetailesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] OrderDetailes orderDetailes)
        {
            bool f = orderDetailesServer.PutOrderDetailes(id, orderDetailes);
            if (f)
                return Ok();
            return NotFound();
        }

        // DELETE api/<OrderDetailesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool f = orderDetailesServer.DeleteOrderDetailes(id);
            if (f)
                return Ok();
            return NotFound();
        }
    }
}
