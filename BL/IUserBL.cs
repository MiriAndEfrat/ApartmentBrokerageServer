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

        public Task<List<Person>> GetAll();
        public Task<Person> GetById(int id);
        public Task<Person> GetByIdNumberAndPassword(int identity_number, string password);
        public Task PostUser(Person person,List<int>userType);
        public Task PutUser(int id, Person person, List<User> userType);
    }
}