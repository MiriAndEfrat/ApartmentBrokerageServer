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

    public class AreaController : ControllerBase
    {
        IAreaBL _areaBL;
        
        public AreaController(IAreaBL areaBL)
        {
            _areaBL = areaBL;
        }

        // GET: api/<SubscriptionTypeController>
        [HttpGet]
        public async Task<List<Area>> Get()
        {
            return await _areaBL.GetAll();
        }

        // POST api/<SubscriptionTypeController>
        [HttpPost]
        public async Task Post([FromBody] Area area)
        {
            await _areaBL.PostArea(area);
        }

        // PUT api/<SubscriptionTypeController>
        [HttpPut]
        public async Task Put([FromBody] Area area)
        {
            await _areaBL.PutArea(area);
        }

        // DELETE api/<SubscriptionTypeController>/5    
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _areaBL.DeleteArea(id);
        }
    }
}
