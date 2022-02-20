using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICityDL
    {
        Task DeleteCity(int id);
        Task<List<City>> GetAll();
        Task<List<City>> GetByAreaId(int id);
        Task PostCity(City city);
        Task PutCity(City city);
    }
}