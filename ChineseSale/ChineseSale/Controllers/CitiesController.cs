using ChineseSale.Entities;
using ChineseSale.Servers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        static readonly CitiesServer citiesServer = new CitiesServer();
        // GET: api/<CitiesController>
        [HttpGet]
        public ActionResult<List<Cities>> Get()
        {
            List<Cities> res=citiesServer.GetCities();
            return Ok(res);
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public ActionResult<Cities> Get(int id)
        {
            Cities city =citiesServer.GetCitiesById(id);
            if(city != null)
                return Ok(city);
            return NotFound();
        }

        // POST api/<CitiesController>
        [HttpPost]
        public ActionResult Post([FromBody] Cities city)
        {
            citiesServer.PostCities(city);
            return Ok();
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cities city)
        {
            bool f = citiesServer.PutCities(id, city);
            if (f)
                return Ok();
            return NotFound();
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool f = citiesServer.DeleteCities(id);
            if (f)
                return Ok();
            return NotFound();
        }
    }
}
