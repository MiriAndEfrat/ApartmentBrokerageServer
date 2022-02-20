using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StreetBL : IStreetBL
    {
        IStreetDL _streetDL;
        public StreetBL(IStreetDL StreetDL)
        {
            _streetDL = StreetDL;
        }
        public async Task<List<Street>> GetAll()
        {
            return await _streetDL.GetAll();
        }

        public async Task PostStreet(Street street)
        {
            await _streetDL.PostStreet(street);
        }

        public async Task PutStreet(Street street)
        {
            await _streetDL.PutStreet(street);
        }
        public async Task DeleteStreet(int id)
        {
            await _streetDL.DeleteStreet(id);
        }
    }
}
