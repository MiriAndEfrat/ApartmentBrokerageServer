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
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentBrokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubscriptionPerUserController : ControllerBase
    {

        ISubscriptionPerUserBL _subscriptionPerUserBL;
        ISubscriberPropertyDetailsBL _subscriberPropertyDetailsBL;
        ILogger<UserController> _logger;
        IMapper _mapper;

        public SubscriptionPerUserController(ISubscriptionPerUserBL subscriptionPerUserBL, ISubscriberPropertyDetailsBL subscriberPropertyDetailsBL, ILogger<UserController> logger, IMapper mapper)
        {
            _subscriptionPerUserBL = subscriptionPerUserBL;
            _subscriberPropertyDetailsBL = subscriberPropertyDetailsBL;
            _logger = logger;
            _mapper = mapper;
        }

        
        // GET api/<SubscriptionPerUserController>/5
        [HttpGet("{id}")]
        public async Task<List<SubscriptionPerUser>> Get(int id)
        {
            return await _subscriptionPerUserBL.GetSubscriptionsById(id);
        }

        // POST api/<SubscriptionPerUserController>
        [HttpPost]
        public async Task<int> Post([FromBody] SubscriptionAndPropertyDetailsDTO subscriptionAndPropertyDetailsDTO)
        {
            var subscription = _mapper.Map<SubscriptionAndPropertyDetailsDTO, SubscriptionPerUser>(subscriptionAndPropertyDetailsDTO);
            var propertyDetail = _mapper.Map<SubscriptionAndPropertyDetailsDTO, SubscriberPropertyDetail>(subscriptionAndPropertyDetailsDTO);
            int subscriptionPerUser_id = await _subscriptionPerUserBL.PostSubscriptionPerUser(subscription);
            propertyDetail.SubscriptionPerUserId = subscriptionPerUser_id;
            await _subscriberPropertyDetailsBL.PostSubscriberPropertyDetails(propertyDetail);
            return subscriptionPerUser_id;
        }

       

    }
}
