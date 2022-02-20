using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class PropertyDetailDL : IPropertyDetailDL
    {
        ApartmentBrokerageContext _data;
        public PropertyDetailDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }

        public async Task<List<PropertyDetail>> GetByArea(int id)
        {
            var properties = await _data.PropertyDetails.Include(p=>p.Street.City.AreaPerCities.Where(c=>c.AreaId==id)).ToListAsync();
           
            

            return  null;

        }
        public async Task<List<PropertyDetail>> GetByUserId(int id)
        {
            return await _data.PropertyDetails.Where(a => a.UserId == id).ToListAsync(); 
        }

        public async Task PostPropertyDetail(PropertyDetail propertyDetail)
        {
            await _data.PropertyDetails.AddAsync(propertyDetail);
            await _data.SaveChangesAsync();

        }
        public async Task PutPropertyDetail(int id, PropertyDetail propertyDetail)
        {
            var property = await _data.PropertyDetails.FindAsync(id);
            if (property != null)
            {
                _data.Entry(property).CurrentValues.SetValues(propertyDetail);
                await _data.SaveChangesAsync();
            }

        }
        public async Task DeletePropertyDetail(int id)
        {
            var propToDelete = await _data.PropertyDetails.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (propToDelete != null)
            {
                _data.PropertyDetails.Remove(propToDelete);
                await _data.SaveChangesAsync();
            }
        }
    }
}

