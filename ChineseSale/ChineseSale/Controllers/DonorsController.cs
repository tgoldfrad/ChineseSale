using ChineseSale.Entities;
using ChineseSale.Servers;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        readonly DonorsServer _donorsServer ;
        public DonorsController(DonorsServer donorsServer)
        {
            _donorsServer = donorsServer;
        }

        // GET: api/<DonorsController>
        [HttpGet]
        public ActionResult<List<Donors>> Get()
        {
            List<Donors> res = _donorsServer.GetDonors();
            return res;
        }

        // GET api/<DonorsController>/5
        [HttpGet("{id}")]
        public ActionResult<Donors> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Donors donor = _donorsServer.GetDonorsById(id);
            if(donor==null)
            {
                return NotFound();
            }
            return donor;
        }

        // POST api/<DonorsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Donors d)
        {
           if(_donorsServer.AddDonors(d))
                return true;
           return BadRequest();
        }

        // PUT api/<DonorsController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Donors d)
        {
            if (id <= 0)
                return BadRequest();
            bool f=_donorsServer.UpdateDonors(id, d);
            if(f)
            {
                return true;
            }
            return NotFound();
            

        }

        // DELETE api/<DonorsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = _donorsServer.DeleteDonors(id);
            if (f)
            {
                return true;
            }
            return NotFound();

        }
    }
}
