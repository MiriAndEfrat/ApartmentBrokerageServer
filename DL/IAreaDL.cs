using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IAreaDL
    {
        Task DeleteArea(int id);
        Task<List<Area>> GetAll();
        Task PostArea(Area area);
        Task PutArea(Area area);
    }
}