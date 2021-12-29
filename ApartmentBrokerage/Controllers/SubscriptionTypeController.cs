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
    public class SubscriptionTypeController : ControllerBase
    {
        ISubscriptionTypeBL subscriptionTypeBL;
        public SubscriptionTypeController(ISubscriptionTypeBL subscriptionTypeBL)
        {
            this.subscriptionTypeBL = subscriptionTypeBL;
        }

        // GET: api/<SubscriptionTypeController>
        [HttpGet]
        public async Task<List<SubscriptionType>> Get()
        {
            return await subscriptionTypeBL.GetAll();
        }

        // POST api/<SubscriptionTypeController>
        [HttpPost]
        public async Task Post([FromBody] SubscriptionType subscriptionType)
        {
            await subscriptionTypeBL.PostSubscriptionType(subscriptionType);
        }

        // PUT api/<SubscriptionTypeController>/5
        [HttpPut]
        public async Task Put([FromBody] SubscriptionType subscriptionType)
        {
            await subscriptionTypeBL.PutSubscriptionType(subscriptionType);
        }

        // DELETE api/<SubscriptionTypeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await subscriptionTypeBL.DeleteSubscriptionType(id);
        }
    }
}
