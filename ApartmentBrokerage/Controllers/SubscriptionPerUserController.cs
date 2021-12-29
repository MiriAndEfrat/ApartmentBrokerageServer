using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentBrokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPerUserController : ControllerBase
    {

        ISubscriptionPerUserBL subscriptionPerUserBL;
        ISubscriberPropertyDetailsBL subscriberPropertyDetailsBL;
        ILogger<UserController> logger;
        IMapper mapper;
        
        public SubscriptionPerUserController(ISubscriptionPerUserBL subscriptionPerUserBL, ISubscriberPropertyDetailsBL subscriberPropertyDetailsBL, ILogger<UserController> logger, IMapper mapper)
        {
            this.subscriptionPerUserBL = subscriptionPerUserBL;
            this.subscriberPropertyDetailsBL = subscriberPropertyDetailsBL;
            this.logger = logger;
            this.mapper = mapper;
        }

        //// GET: api/<SubscriptionPerUserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        // GET api/<SubscriptionPerUserController>/5
        [HttpGet("{id}")]
        public async Task<List<SubscriptionPerUser>> Get(int id)
        {
            return await subscriptionPerUserBL.GetSubscriptionsById(id);
        }

        // POST api/<SubscriptionPerUserController>
        [HttpPost]
        public async Task<int> Post([FromBody] SubscriptionAndPropertyDetailsDTO subscriptionAndPropertyDetailsDTO)
        {
            var subscription = mapper.Map<SubscriptionAndPropertyDetailsDTO, SubscriptionPerUser>(subscriptionAndPropertyDetailsDTO);
            var propertyDetail = mapper.Map<SubscriptionAndPropertyDetailsDTO,SubscriberPropertyDetail>(subscriptionAndPropertyDetailsDTO);
            int subscriptionPerUser_id = await subscriptionPerUserBL.PostSubscriptionPerUser(subscription);
            propertyDetail.SubscriptionPerUserId = subscriptionPerUser_id;
            await subscriberPropertyDetailsBL.PostSubscriberPropertyDetails(propertyDetail);
            return subscriptionPerUser_id;
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
