using ChineseSale.Core.Entities;
using ChineseSale.Core.IServices;
using ChineseSale.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        readonly IOrderDetailsService _orderDetailsService;
        public OrderDetailsController(IOrderDetailsService orderDetailesService)
        {
            _orderDetailsService = orderDetailesService;
        }
        // GET: api/<OrderDetailsController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetails>> Get()
        {
            return _orderDetailsService.GetAll();
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDetails> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            OrderDetails orderDetailes = _orderDetailsService.GetById(id);
            if (orderDetailes == null)
            {
                return NotFound();
            }
            return orderDetailes;
        }

        // POST api/<OrderDetailsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] OrderDetails orderDetails)
        {
            if (_orderDetailsService.Add(orderDetails)!=null)
                return true;
            return BadRequest();
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] OrderDetails orderDetailes)
        {
            if (id <= 0)
                return BadRequest();
            bool f = _orderDetailsService.Update(id, orderDetailes);
            if (f)
            {
                return true;
            }
            return NotFound();
        }

        // DELETE api/<OrderDetailsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = _orderDetailsService.Delete(id);
            if (f)
            {
                return true;
            }
            return NotFound();
        }
    }
}
