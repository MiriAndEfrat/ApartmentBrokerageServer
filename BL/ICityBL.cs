using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICityBL
    {
        public Task<List<City>> GetAll();
        public Task PostCity(City city);
        public Task PutCity(City city);
        public Task DeleteCity(int id);
    }
}