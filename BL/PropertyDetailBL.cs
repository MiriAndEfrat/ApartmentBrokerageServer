using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class PropertyDetailBL: IPropertyDetailBL
    {
        IPropertyDetailDL _propertyDetailDL;

        public PropertyDetailBL(IPropertyDetailDL propertyDetailDL)
        {
            _propertyDetailDL = propertyDetailDL;
        }


        public async Task<List<PropertyDetail>> GetByArea(int id)
        {
           return await _propertyDetailDL.GetByArea(id);
        }

        public async Task<List<PropertyDetail>> GetByUserId(int id)
        {
           return await _propertyDetailDL.GetByUserId(id);
        }

        public async Task PostPropertyDetail(PropertyDetail propertyDetail)
        {
            await _propertyDetailDL.PostPropertyDetail(propertyDetail);
        }
        public async Task PutPropertyDetail(int id, PropertyDetail propertyDetail)
        {
            await _propertyDetailDL.PutPropertyDetail(id,propertyDetail);
        }
        public async Task DeletePropertyDetail(int id)
        {
            await _propertyDetailDL.DeletePropertyDetail(id);
        }
    }
}
