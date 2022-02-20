using Entity;
using System.Threading.Tasks;

namespace DL
{
    public interface INeighborhoodDL
    {
        Task DeleteNeighborhood(int id);
        Task<System.Collections.Generic.List<Neighborhood>> GetAll();
        Task PostNeighborhood(Neighborhood neighborhood);
        Task PutNeighborhood(Neighborhood neighborhood);
    }
}