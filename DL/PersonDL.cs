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
        ApartmentBrokerageContext _data;
        public PersonDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }

        public async Task<List<Person>> GetAll()
        {
            var a= await _data.People.Include(p=>p.Users).ToListAsync();
            return a;
        }

        public async Task<Person> GetById(int id)
        {
            //return await _data.People.FindAsync(id);
            //return await data.People.Where(person => person.Id == id).FirstOrDefaultAsync();
            return await _data.People.Include(p => p.Users).Where(person => person.Id == id).FirstOrDefaultAsync();


        }

        public async Task<Person> GetByIdNumberAndPassword(string identity_number)
        {
            return await _data.People.Include(p => p.Users).Where(person => person.IdentityNumber.Equals(identity_number)).FirstOrDefaultAsync();

            //return await data.People.Where(person => person.IdentityNumber.Equals(identity_number)&&person.Password.Equals(password)).FirstOrDefaultAsync();
        }

        public async Task<Person> PostPerson(Person person)
        {
            await _data.People.AddAsync(person);
            await _data.SaveChangesAsync();
            return await _data.People.Where(p=>p.IdentityNumber.Equals(person.IdentityNumber)).FirstOrDefaultAsync();
            //return await data.People.FindAsync(person.IdentityNumber);
        }

        public async Task PutPerson(Person person)
        {
            Person p = await _data.People.FindAsync(person.Id);
            if (p != null)
            {
                _data.Entry(p).CurrentValues.SetValues(person);
                await _data.SaveChangesAsync();
            }
        }

    }
}
