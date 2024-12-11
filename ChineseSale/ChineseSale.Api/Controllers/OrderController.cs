using ChineseSale.Core.Entities;
using ChineseSale.Core.IServices;
using ChineseSale.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _orderService.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Order order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Order order)
        {
            if (_orderService.Add(order) != null)
                return true;
            return BadRequest();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Order order)
        {
            if (id <= 0)
                return BadRequest();
            bool f = _orderService.Update(id, order);
            if (f)
            {
                return true;
            }
            return NotFound();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = _orderService.Delete(id);
            if (f)
            {
                return true;
            }
            return NotFound();
        }
    }
}
