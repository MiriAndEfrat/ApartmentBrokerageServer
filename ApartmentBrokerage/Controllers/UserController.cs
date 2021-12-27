using Microsoft.AspNetCore.Mvc;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using AutoMapper;
using Entity;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentBrokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        IMapper mapper;
        ILogger<UserController> logger;


        // GET: api/<UserController>

        public UserController(IUserBL userBL, IMapper mapper,ILogger<UserController> logger)
        {
            this.userBL = userBL;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<List<PersonDTO>> Get()
        {
            try {
                var people = await userBL.GetAll();
                var peopleDTO = mapper.Map<List<Person>, List<PersonDTO>>(people);
                return peopleDTO;

            }
            catch(Exception ex)
            {
                logger.LogError("server wrong");
            }
            return null;

        }



        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<PersonDTO> Get(int id)
        {
            var person = await userBL.GetById(id);
            var personDTO = mapper.Map<Person, PersonDTO>(person);
            return personDTO;
            
        }

        // GET api/<UserController>/5/123
        [HttpGet("{identity_number}/{password}")]
        public async Task<PersonDTO> Get(int identity_number, string password)
        {
            var person = await userBL.GetByIdNumberAndPassword(identity_number, password);
            var personDTO = mapper.Map<Person, PersonDTO>(person);
            return personDTO;

        }

        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] PersonDTO personDTO)
        {
            Person person=mapper.Map<PersonDTO,Person>(personDTO);
            List<int> userType = personDTO.UserType;
            //foreach (var i in personDTO.UserType)
            //{
            //    user.Add(new User { PersonId = personDTO.Id, UserTypeId = i });
            //}


            await userBL.PostUser(person, userType);
            //await userBL.PostUser(person);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PersonDTO personDTO)
        {
            Person person = mapper.Map<PersonDTO, Person>(personDTO);
            List<User> user = new List<User>();
            foreach (var i in personDTO.UserType)
            {
                user.Add(new User { PersonId = personDTO.Id, UserTypeId = i });
            }


            await userBL.PutUser(id, person, user);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
