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
    public class UserTypeController : ControllerBase
    {
        IUserTypeBL _userTypeBL;
        public UserTypeController(IUserTypeBL userTypeBL)
        {
            _userTypeBL = userTypeBL;
        }

        // GET: api/<SubscriptionTypeController>
        [HttpGet]
        public async Task<List<UserType>> Get()
        {
            return await _userTypeBL.GetAll();
        }

        // POST api/<SubscriptionTypeController>
        [HttpPost]
        public async Task Post([FromBody] UserType userType)
        {
            await _userTypeBL.PostUserType(userType);
        }

        // PUT api/<SubscriptionTypeController>
        [HttpPut]
        public async Task Put([FromBody] UserType userType)
        {
            await _userTypeBL.PutUserType(userType);
        }

        // DELETE api/<SubscriptionTypeController>/5    
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userTypeBL.DeleteUserType(id);
        }
    }
}
