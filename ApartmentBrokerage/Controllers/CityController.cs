using BL;
using Entity;
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
    public class CityController : ControllerBase
    {
        ICityBL cityBL;
        public CityController(ICityBL cityBL)
        {
            this.cityBL = cityBL;
        }
        
        // GET: api/<CityController>
        [HttpGet]
        public async Task<List<City>> Get()
        {
            return await cityBL.GetAll();
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task Post([FromBody] City city)
        {
            await cityBL.PostCity(city);
        }

        // PUT api/<CityController>/5
        [HttpPut]
        public async Task Put([FromBody] City city)
        {
            await cityBL.PutCity(city);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await cityBL.DeleteCity(id);
        }
    }
}
