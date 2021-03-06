using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStreetDL
    {
        Task DeleteStreet(int id);
        Task<List<Street>> GetAll();
        Task PostStreet(Street street);
        Task PutStreet(Street street);
    }
}