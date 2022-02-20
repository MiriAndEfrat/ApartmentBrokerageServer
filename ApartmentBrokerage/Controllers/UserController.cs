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
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentBrokerage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        IUserBL _userBL;
       //
       IMapper _mapper;
        ILogger<UserController> _logger;
        //IConfiguration configuration;

        public UserController(IUserBL userBL, ILogger<UserController> logger, IMapper mapper)//*IConfiguration configuration*/
        {
            _userBL = userBL;
            _mapper = mapper;
            _logger = logger;
           // this.configuration = configuration;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<PersonDTO>> Get()
        {
            return await _userBL.GetAll();
            //var peopleDTO = mapper.Map<List<Person>, List<PersonDTO>>(people);
            //return WithoutPasswords(peopleDTO);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<PersonDTO> Get(int id)
        {
            //var person = await userBL.GetById(id);
            //return WithoutPassword(mapper.Map<Person, PersonDTO>(person));
            return await  _userBL.GetById(id);
        }

        // GET api/<UserController>/5/123
        //[HttpGet("{identity_number}/{password}")]
        //public async Task<PersonDTO> Get(string identity_number, string password)
        //{
        //    var person = await userBL.GetByIdNumberAndPassword(identity_number, password);
        //    return mapper.Map<Person, PersonDTO>(person);

        //}
        [HttpPost("login")]
        [AllowAnonymous]
                
        public async Task<PersonDTO> Post([FromBody] UserLogInDTO userLogInDTO)
        {
            var user = await _userBL.GetByIdNumberAndPassword(userLogInDTO.IdentityNumber, userLogInDTO.Password);
            return await _userBL.PostLogIn(user);
        }


        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<int> Post([FromBody] PersonDTO personDTO)
        {
            Person person = _mapper.Map<PersonDTO, Person>(personDTO);
            List<int> userType = personDTO.UserType;
            return await _userBL.PostUser(person, userType);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task Put([FromBody] PersonDTO personDTO)
        {
            Person person = _mapper.Map<PersonDTO, Person>(personDTO);
            List<User> user = new List<User>();
            foreach (var i in personDTO.UserType)
            {
                user.Add(new User { PersonId = person.Id, UserTypeId = i });
            }
            await _userBL.PutUser(person, user);
        }

        // DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        //public static List<PersonDTO> WithoutPasswords(List<PersonDTO> users)
        //{
        //    return users.Select(x => WithoutPassword(x)).ToList();
        //}


        //public static PersonDTO WithoutPassword(PersonDTO personDTO)
        //{
        //    personDTO.Password = null;
        //    return personDTO;
        //}

    }
}
