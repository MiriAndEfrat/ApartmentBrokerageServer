using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IPersonDL
    {

        public Task<List<Person>> GetAll();

        public Task<Person> GetById(int id);
        public Task<Person> GetByIdNumberAndPassword(string identity_number);
        public Task<Person> PostPerson(Person person);
        public Task PutPerson(Person person);

    }
}
