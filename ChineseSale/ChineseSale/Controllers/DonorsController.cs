using ChineseSale.Entities;
using ChineseSale.Servers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        static readonly DonorsServer donorsServer = new DonorsServer();
        // GET: api/<DonorsController>
        [HttpGet]
        public ActionResult<List<Donors>> Get()
        {
            List<Donors> res = donorsServer.GetDonors();
            return Ok(res);
        }

        // GET api/<DonorsController>/5
        [HttpGet("{id}")]
        public ActionResult<Donors> Get(int id)
        {
            Donors donor = donorsServer.GetDonorsById(id);
            if(donor==null)
            {
                return NotFound();
            }
            return Ok(donor);
        }

        // POST api/<DonorsController>
        [HttpPost]
        public ActionResult Post([FromBody] Donors d)
        {
            donorsServer.PostDonors(d);
            return Ok(true);
        }

        // PUT api/<DonorsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Donors d)
        {
            bool f=donorsServer.PutDonors(id, d);
            if(f)
            {
                return Ok();
            }
            return NotFound();
            

        }

        // DELETE api/<DonorsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool f = donorsServer.DeleteDonors(id);
            if (f)
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
