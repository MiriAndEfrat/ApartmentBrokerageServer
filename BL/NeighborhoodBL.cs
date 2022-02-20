using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class NeighborhoodBL : INeighborhoodBL
    {
        INeighborhoodDL _neighborhoodDL;

        public NeighborhoodBL(INeighborhoodDL NeighborhoodDL)
        {
            _neighborhoodDL = NeighborhoodDL;
        }
        public async Task<List<Neighborhood>> GetAll()
        {
            return await _neighborhoodDL.GetAll();
        }
        public async Task PostNeighborhood(Neighborhood neighborhood)
        {
            await _neighborhoodDL.PostNeighborhood(neighborhood);
        }

        public async Task PutNeighborhood(Neighborhood neighborhood)
        {
            await _neighborhoodDL.PutNeighborhood(neighborhood);
        }

        public async Task DeleteNeighborhood(int id)
        {
            await _neighborhoodDL.DeleteNeighborhood(id);
        }
    }
}
