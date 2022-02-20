using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class AreaDL : IAreaDL
    {
        ApartmentBrokerageContext data;
        public AreaDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }
        public async Task<List<Area>> GetAll()
        {
            return await data.Areas.ToListAsync();
        }
        public async Task PostArea(Area area)
        {
            await data.Areas.AddAsync(area);
            await data.SaveChangesAsync();
        }
        public async Task PutArea(Area area)
        {
            Area a = await data.Areas.FindAsync(area.Id);
            if (a != null) { 
            data.Entry(a).CurrentValues.SetValues(area);
            await data.SaveChangesAsync();
            }
        }
        public async Task DeleteArea(int id)
        {
            Area a = await data.Areas.FindAsync(id);
            if (a != null)
            {
                data.Areas.Remove(a);
                await data.SaveChangesAsync();
            }
        }
    }
}
