using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentBrokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPerUserController : ControllerBase
    {

        ISubscriptionPerUserBL subscriptionPerUserBL;
        ILogger<UserController> logger;

        //// GET: api/<SubscriptionPerUserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public SubscriptionPerUserController(ISubscriptionPerUserBL subscriptionPerUserBL, ILogger<UserController> logger)
        {
            this.subscriptionPerUserBL = subscriptionPerUserBL;
            this.logger = logger;
        }

        // GET api/<SubscriptionPerUserController>/5
        [HttpGet("{id}")]
        public async Task<List<SubscriptionPerUser>> Get(int id)
        {
            return await subscriptionPerUserBL.GetSubscriptionsById(id);
        }

        // POST api/<SubscriptionPerUserController>
        [HttpPost]
        public void Post([FromBody] SubscriptionPerUser subscription, [FromBody] SubscriberPropertyDetail propertyDetail)
        {


        }

        //// PUT api/<SubscriptionPerUserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SubscriptionPerUserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}
