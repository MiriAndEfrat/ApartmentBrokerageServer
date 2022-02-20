using BL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentBrokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CityController : ControllerBase
    {
        ICityBL _cityBL;
        public CityController(ICityBL cityBL)
        {
            _cityBL = cityBL;
        }

        // GET: api/<CityController>
        [HttpGet]
        public async Task<List<City>> Get()
        {
            //List<City> l = await cityBL.GetAll();
            return await _cityBL.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<List<City>> Get(int id)
        {
            //List<City> l = await cityBL.GetAll();
            return await _cityBL.GetByAreaId(id);
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task Post([FromBody] City city)
        {
            await _cityBL.PostCity(city);
        }

        // PUT api/<CityController>/5
        [HttpPut]
        public async Task Put([FromBody] City city)
        {
            await _cityBL.PutCity(city);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _cityBL.DeleteCity(id);
        }
    }
}
