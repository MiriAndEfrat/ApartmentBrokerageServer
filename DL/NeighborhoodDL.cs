using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class NeighborhoodDL : INeighborhoodDL
    {

        ApartmentBrokerageContext _data;

        public NeighborhoodDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }

        public async Task<List<Neighborhood>> GetAll()
        {
            return await _data.Neighborhoods.ToListAsync();
        }


        public async Task PostNeighborhood(Neighborhood neighborhood)
        {
            await _data.Neighborhoods.AddAsync(neighborhood);
            await _data.SaveChangesAsync();
        }

        public async Task PutNeighborhood(Neighborhood neighborhood)
        {
            var a = await _data.Neighborhoods.FindAsync(neighborhood.Id);
            if (a != null)
            {
                _data.Entry(a).CurrentValues.SetValues(neighborhood);
                await _data.SaveChangesAsync();
            }

        }

        public async Task DeleteNeighborhood(int id)
        {

            var a = await _data.Neighborhoods.FindAsync(id);
            if (a != null)
            {
                _data.Neighborhoods.Remove(a);
                await _data.SaveChangesAsync();
            }
        }


    }
}
