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
    public class SubscriptionTypeController : ControllerBase
    {
        ISubscriptionTypeBL _subscriptionTypeBL;
        public SubscriptionTypeController(ISubscriptionTypeBL subscriptionTypeBL)
        {
           _subscriptionTypeBL = subscriptionTypeBL;
        }

        // GET: api/<SubscriptionTypeController>
        [HttpGet]
        public async Task<List<SubscriptionType>> Get()
        {
            return await _subscriptionTypeBL.GetAll();
        }

        // POST api/<SubscriptionTypeController>
        [HttpPost]
        public async Task Post([FromBody] SubscriptionType subscriptionType)
        {
            await _subscriptionTypeBL.PostSubscriptionType(subscriptionType);
        }

        // PUT api/<SubscriptionTypeController>/5
        [HttpPut]
        public async Task Put([FromBody] SubscriptionType subscriptionType)
        {
            await _subscriptionTypeBL.PutSubscriptionType(subscriptionType);
        }

        // DELETE api/<SubscriptionTypeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _subscriptionTypeBL.DeleteSubscriptionType(id);
        }
    }
}
