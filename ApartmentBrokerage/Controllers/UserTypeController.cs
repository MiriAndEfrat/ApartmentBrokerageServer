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
    public class UserTypeController : ControllerBase
    {
        IUserTypeBL userTypeBL;
        public UserTypeController(IUserTypeBL userTypeBL)
        {
            this.userTypeBL = userTypeBL;
        }

        // GET: api/<SubscriptionTypeController>
        [HttpGet]
        public async Task<List<UserType>> Get()
        {
            return await userTypeBL.GetAll();
        }

        // POST api/<SubscriptionTypeController>
        [HttpPost]
        public async Task Post([FromBody] UserType userType)
        {
            await userTypeBL.PostUserType(userType);
        }

        // PUT api/<SubscriptionTypeController>
        [HttpPut]
        public async Task Put([FromBody] UserType userType)
        {
            await userTypeBL.PutUserType(userType);
        }

        // DELETE api/<SubscriptionTypeController>/5    
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await userTypeBL.DeleteUserType(id);
        }
    }
}
