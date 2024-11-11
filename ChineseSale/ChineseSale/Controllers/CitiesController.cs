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
            return res;
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public ActionResult<Cities> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            Cities city =citiesServer.GetCitiesById(id);
            if(city != null)
                return city;
            return NotFound();
        }

        // POST api/<CitiesController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Cities city)
        {
            citiesServer.AddCities(city);
            return true;
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Cities city)
        {
            if (id <= 0)
                return BadRequest();
            bool f = citiesServer.UpdateCities(id, city);
            if (f)
                return true;
            return NotFound();
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = citiesServer.DeleteCities(id);
            if (f)
                return true;
            return NotFound();
        }
    }
}
