using DTO;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class PersonDL: IPersonDL
    {
        ApartmentBrokerageContext data;
        public PersonDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }

        public async Task<List<Person>> GetAll()
        {
            return await data.People.ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await data.People.Where(person => person.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Person> GetByIdNumberAndPassword(int identity_number, string password)
        {
            return await data.People.Where(person => person.IdentityNumber.Equals(identity_number)&&person.Password.Equals(password)).FirstOrDefaultAsync();
        }

        public async Task<Person> PostPerson(Person person)
        {
            await data.People.AddAsync(person);
            await data.SaveChangesAsync();
            return await data.People.FindAsync(person.IdentityNumber);
           
        }

        public async Task PutPerson(int id,Person person)
        {
            Person p = await data.People.FindAsync(id);
            data.Entry(p).CurrentValues.SetValues(person);
            await data.SaveChangesAsync();

        }

    }
}
