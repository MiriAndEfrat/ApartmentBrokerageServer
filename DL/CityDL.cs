using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CityDL : ICityDL
    {
        ApartmentBrokerageContext data;
        public CityDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }
        public async Task<List<City>> GetAll()
        {
            return await data.Cities.Include(c => c.AreaPerCities).ToListAsync();
        }

        public async Task<List<City>> GetByAreaId(int id)
        {
            //return await data.Cities.Where(c => c.AreaPerCities == id).ToListAsync();
            List<City> lCity= await data.Cities.Include(c => c.AreaPerCities.Where(c => c.AreaId == id)).ToListAsync();//not work
            return  lCity.Where(c=>c.AreaPerCities.Count() != 0).ToList();

        }
        public async Task PostCity(City city)
        {
            await data.Cities.AddAsync(city);
            await data.SaveChangesAsync();
        }
        public async Task PutCity(City city)
        {

            City c = await data.Cities.FindAsync(city.Id);
            //.Include(c => c.AreaPerCities);
            foreach (var i in city.AreaPerCities)
            {
                AreaPerCity a = await data.AreaPerCities.FindAsync(i.Id);
                if (a != null) { 
                data.Entry(a).CurrentValues.SetValues(i);
                }
            }
            if (c != null) { }
            data.Entry(c).CurrentValues.SetValues(city);
            await data.SaveChangesAsync();
        }
        public async Task DeleteCity(int id)
        {
            //City c = await data.Cities.FindAsync(id);
            List<AreaPerCity> l = await data.AreaPerCities.Where(a => a.CityId == id).ToListAsync();
            if (l != null)
            {
                foreach (var i in l)
                {

                    data.AreaPerCities.Remove(i);
                }
            }
            //data.Cities.Remove(c);
            await data.SaveChangesAsync();
        }
    }
}
