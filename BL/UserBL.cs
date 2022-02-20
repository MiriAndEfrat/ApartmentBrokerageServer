using AutoMapper;
using DL;
using DTO;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class UserBL: IUserBL
    {
        IUserDL _userDL;
        IPersonDL _personDL;
        IMapper _mapper;
        IConfiguration _configuration;
        IPasswordHashHelper _passwordHashHelper;

        public UserBL(IUserDL userDL, IPersonDL personDL, IMapper mapper, IConfiguration configuration, IPasswordHashHelper passwordHashHelper)
        {
           _userDL = userDL;
           _personDL = personDL;
           _mapper = mapper;

           _configuration = configuration;
            _passwordHashHelper = passwordHashHelper;
        }

        public async Task<List<PersonDTO>> GetAll()
        {
            //return await personDL.GetAll();
            
            var people = await _personDL.GetAll();
            var peopleDTO = _mapper.Map<List<Person>, List<PersonDTO>>(people);
            return WithoutPasswords(peopleDTO);
        }

        public async Task<PersonDTO> GetById(int id)
        {
            //return await personDL.GetById(id);
            var person = await _personDL.GetById(id);
            //var yyyy = person.Users.Select(u => u.UserTypeId).ToList();
            var d=WithoutPassword(_mapper.Map<Person, PersonDTO>(person));
            return d;
        }

        public async Task<Person> GetByIdNumberAndPassword(string identity_number, string password)
        {
            Person person= await _personDL.GetByIdNumberAndPassword(identity_number);
            string Hashedpassword = _passwordHashHelper.HashPassword(password, person.Salt, 1000, 8);
            if (Hashedpassword.Equals(person.Password.TrimEnd()))
                return person;
            else
                return null;
        }

        public async Task<int> PostUser(Person person,List<int> userType)
        {
            person.Salt= _passwordHashHelper.GenerateSalt(8);
            person.Password = _passwordHashHelper.HashPassword(person.Password, person.Salt, 1000, 8);
            Person p=await _personDL.PostPerson(person);
            List<User> user = new List<User>();
            foreach (var i in userType)
            {
                user.Add(new User { PersonId = p.Id, UserTypeId = i });
            }
            await _userDL.PostUser(user);
            return p.Id;
        }

        public async Task PutUser(Person person, List<User> userType)
        {
            person.Salt = _passwordHashHelper.GenerateSalt(8);
            person.Password = _passwordHashHelper.HashPassword(person.Password, person.Salt, 1000, 8);
            await _personDL.PutPerson(person);
            await _userDL.PutUser(person.Id, userType);

        }


        public async Task<PersonDTO> PostLogIn( Person user)
        {
            //var user = await userBL.GetByIdNumberAndPassword(userLogInDTO.IdentityNumber, userLogInDTO.Password);
            if (user == null) return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return WithoutPassword(_mapper.Map<Person, PersonDTO>(user));

        }



        public static List<PersonDTO> WithoutPasswords(List<PersonDTO> users)
        {
            return users.Select(x => WithoutPassword(x)).ToList();
        }


        public static PersonDTO WithoutPassword(PersonDTO personDTO)
        {
            personDTO.Password = null;
            return personDTO;
        }


    }
}
