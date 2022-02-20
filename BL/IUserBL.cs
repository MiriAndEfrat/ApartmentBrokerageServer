using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        public Task<List<PersonDTO>> GetAll();
        public Task<PersonDTO> GetById(int id);
        public Task<Person> GetByIdNumberAndPassword(string identity_number, string password);
        public Task<int> PostUser(Person person,List<int>userType);
        public Task PutUser(Person person, List<User> userType);
        public Task<PersonDTO> PostLogIn(Person user);
    }
}