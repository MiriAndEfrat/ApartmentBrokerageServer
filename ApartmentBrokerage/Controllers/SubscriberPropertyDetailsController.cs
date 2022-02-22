using BL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class SubscriberPropertyDetailsController : ControllerBase
    {
        ISubscriberPropertyDetailsBL _subscriberPropertyDetailsBL;
        ILogger<UserController> _logger;

        
        public SubscriberPropertyDetailsController(ISubscriberPropertyDetailsBL subscriberPropertyDetailsBL, ILogger<UserController> logger)
        {
            _subscriberPropertyDetailsBL = subscriberPropertyDetailsBL;
            _logger = logger;
        }

        
        // GET api/<SubscriberPropertyDetailsController>/5
        [HttpGet("{id}")]
        public async Task<SubscriberPropertyDetail> Get(int id)
        {
            return await _subscriberPropertyDetailsBL.GetPropertyDetailsBySubscriberId(id);
        }

        
        // PUT api/<SubscriberPropertyDetailsController>
        [HttpPut]
        public async Task Put([FromBody] SubscriberPropertyDetail property)
        {
            await _subscriberPropertyDetailsBL.PutPropertyDetails(property);
        }

        
    }
}
