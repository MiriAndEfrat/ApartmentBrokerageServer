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
    public class StreetController : ControllerBase
    {

        IStreetBL _streetBL;

        public StreetController(IStreetBL StreetBL)
        {
            _streetBL = StreetBL;
        }
        // GET: api/<StreetController>
        [HttpGet]
        public async Task<List<Street>> Get()
        {
            return await _streetBL.GetAll();
        }


        // POST api/<StreetController>
        [HttpPost]
        public async Task Post([FromBody] Street street)
        {
            await _streetBL.PostStreet(street);
        }

        // PUT api/<StreetController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] Street street)
        {
            await _streetBL.PutStreet(street);
        }

        // DELETE api/<StreetController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _streetBL.DeleteStreet(id);
        }
    }
}
