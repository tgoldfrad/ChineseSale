using ChineseSale.Core.Entities;
using ChineseSale.Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        // GET: api/<DonorController>
        [HttpGet]
        public ActionResult<IEnumerable<Donor>> Get()
        {
            return _donorService.GetAll();
        }

        // GET api/<DonorController>/5
        [HttpGet("{id}")]
        public ActionResult<Donor> Get(string id)
        {
            //if (id <= 0)
            //    return BadRequest();
            Donor donor = _donorService.GetById(id);
            if (donor == null)
            {
                return NotFound();
            }
            return donor;
        }

        // POST api/<DonorController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Donor d)
        {
            if (_donorService.Add(d) != null)
                return true;
            return BadRequest();
        }

        // PUT api/<DonorController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(string id, [FromBody] Donor d)
        {
            //if (id <= 0)
            //    return BadRequest();
            bool f = _donorService.Update(id, d);
            if (f)
            {
                return true;
            }
            return NotFound();


        }

        // DELETE api/<DonorController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            bool f = _donorService.Delete(id);
            if (f)
            {
                return true;
            }
            return NotFound();

        }
    }
}
