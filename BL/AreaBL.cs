using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AreaBL : IAreaBL
    {
        IAreaDL _areaDL;
        public AreaBL(IAreaDL areaDL)
        {
            _areaDL = areaDL;
        }
        public async Task<List<Area>> GetAll()
        {
            return await _areaDL.GetAll();
        }
        public async Task PostArea(Area area)
        {
            await _areaDL.PostArea(area);
        }
        public async Task PutArea(Area area)
        {
            await _areaDL.PutArea(area);
        }
        public async Task DeleteArea(int id)
        {
            await _areaDL.DeleteArea(id);
        }
    }
}
