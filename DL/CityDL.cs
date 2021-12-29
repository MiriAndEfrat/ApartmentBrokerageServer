using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CityDL: ICityDL
    {
        ApartmentBrokerageContext data;
        public CityDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }
        public async Task<List<City>> GetAll()
        {
            return await data.Cities.ToListAsync();
        }
        public async Task PostCity(City city)
        {
            await data.Cities.AddAsync(city);
            await data.SaveChangesAsync();
        }
        public async Task PutCity(City city)
        {
            City c = await data.Cities.FindAsync(city.Id);
            data.Entry(c).CurrentValues.SetValues(city);
            await data.SaveChangesAsync();
        }
        public async Task DeleteCity(int id)
        {
            City c = await data.Cities.FindAsync(id);
            data.Cities.Remove(c);
            await data.SaveChangesAsync();
        }
    }
}
