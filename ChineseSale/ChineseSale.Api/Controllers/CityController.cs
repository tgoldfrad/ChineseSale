using ChineseSale.Core.Entities;
using ChineseSale.Core.IServices;
using ChineseSale.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        // GET: api/<CityController>
        [HttpGet]
        public ActionResult<IEnumerable<City>> Get()
        {
            return _cityService.GetAll();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            City city = _cityService.GetById(id);
            if (city == null)
            {
                return NotFound();
            }
            return city;
        }

        // POST api/<CityController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] City city)
        {
            if (_cityService.Add(city)!=null)
                return true;
            return BadRequest();
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] City city)
        {
            if (id <= 0)
                return BadRequest();
            bool f = _cityService.Update(id, city);
            if (f)
            {
                return true;
            }
            return NotFound();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool f = _cityService.Delete(id);
            if (f)
            {
                return true;
            }
            return NotFound();
        }
    }
}
