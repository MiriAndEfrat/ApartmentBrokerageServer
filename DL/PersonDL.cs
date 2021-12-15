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
    }
}
