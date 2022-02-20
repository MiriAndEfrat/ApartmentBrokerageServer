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
    public class NeighborhoodController : ControllerBase
    {
        INeighborhoodBL _neighborhoodBL;

        public NeighborhoodController(INeighborhoodBL neighborhoodBL)
        {
            _neighborhoodBL = neighborhoodBL;
        }
        // GET: api/<NeighborhoodController>
        [HttpGet]
        public async Task<List<Neighborhood>> Get()
        {
            return await _neighborhoodBL.GetAll();
        }

        // POST api/<NeighborhoodController>
        [HttpPost]
        public async Task Post([FromBody] Neighborhood neighborhood)
        {
            await _neighborhoodBL.PostNeighborhood(neighborhood);
        }

        // PUT api/<NeighborhoodController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] Neighborhood neighborhood)
        {
            await _neighborhoodBL.PutNeighborhood(neighborhood);
        }

        // DELETE api/<NeighborhoodController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _neighborhoodBL.DeleteNeighborhood(id);

        }
    }
}
