using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IAreaBL
    {
        Task DeleteArea(int id);
        Task<List<Area>> GetAll();
        Task PostArea(Area area);
        Task PutArea(Area area);
    }
}