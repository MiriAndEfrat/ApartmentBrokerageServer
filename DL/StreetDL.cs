using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StreetDL : IStreetDL
    {
        ApartmentBrokerageContext _data;
        public StreetDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }
        public async Task<List<Street>> GetAll()
        {
            return await _data.Streets.ToListAsync();

        }
        public async Task PostStreet(Street street)
        {
            await _data.Streets.AddAsync(street);
            await _data.SaveChangesAsync();
        }
        public async Task PutStreet(Street street)
        {
            var a = await _data.Streets.FindAsync(street.Id);
            if (a != null)
            {
                _data.Entry(a).CurrentValues.SetValues(street);
                await _data.SaveChangesAsync();
            }
        }
        public async Task DeleteStreet(int id)
        {
            var a = await _data.Streets.FindAsync(id);
            if (a != null)
            {
                _data.Streets.Remove(a);
                await _data.SaveChangesAsync();
            }
        }
    }
}
