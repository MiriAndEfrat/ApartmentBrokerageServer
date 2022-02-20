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

        //// GET: api/<SubscriptionPerUserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public SubscriberPropertyDetailsController(ISubscriberPropertyDetailsBL subscriberPropertyDetailsBL, ILogger<UserController> logger)
        {
            _subscriberPropertyDetailsBL = subscriberPropertyDetailsBL;
            _logger = logger;
        }

        // GET: api/<SubscriberPropertyDetailsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<SubscriberPropertyDetailsController>/5
        [HttpGet("{id}")]
        public async Task<SubscriberPropertyDetail> Get(int id)
        {
            return await _subscriberPropertyDetailsBL.GetPropertyDetailsBySubscriberId(id);
        }

        // POST api/<SubscriberPropertyDetailsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<SubscriberPropertyDetailsController>/5
        [HttpPut]
        public async Task Put([FromBody] SubscriberPropertyDetail property)
        {
            await _subscriberPropertyDetailsBL.PutPropertyDetails(property);
        }

        // DELETE api/<SubscriberPropertyDetailsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
