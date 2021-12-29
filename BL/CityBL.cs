using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CityBL: ICityBL
    {
        ICityDL cityDL;
        public CityBL(ICityDL cityDL)
        {
            this.cityDL = cityDL;
        }
        public async Task<List<City>> GetAll()
        {
            return await cityDL.GetAll();
        }
        public async Task PostCity(City city)
        {
            await cityDL.PostCity(city);
        }
        public async Task PutCity(City city)
        {
            await cityDL.PutCity(city);
        }
        public async Task DeleteCity(int id)
        {
            await cityDL.DeleteCity(id);
        }
    }
}
