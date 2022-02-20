using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CityBL : ICityBL
    {
        ICityDL _cityDL;
        public CityBL(ICityDL cityDL)
        {
            _cityDL = cityDL;
        }
        public async Task<List<City>> GetAll()
        {
            return await _cityDL.GetAll();
        }
        public async Task<List<City>> GetByAreaId(int id)
        {
            return await _cityDL.GetByAreaId(id);
        }
        public async Task PostCity(City city)
        {
            await _cityDL.PostCity(city);
        }
        public async Task PutCity(City city)
        {
            await _cityDL.PutCity(city);
        }
        public async Task DeleteCity(int id)
        {
            await _cityDL.DeleteCity(id);
        }
    }
}
