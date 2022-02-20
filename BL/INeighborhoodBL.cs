using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface INeighborhoodBL
    {
        Task DeleteNeighborhood(int id);
        Task<List<Neighborhood>> GetAll();
        Task PostNeighborhood(Neighborhood neighborhood );
        Task PutNeighborhood(Neighborhood neighborhood);
    }
}