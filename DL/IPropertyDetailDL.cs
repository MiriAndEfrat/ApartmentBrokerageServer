using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public interface IPropertyDetailDL
    {
        public Task<List<PropertyDetail>> GetByArea(int id);
        public Task<List<PropertyDetail>> GetByUserId(int id);
        public  Task PostPropertyDetail(PropertyDetail propertyDetail);
        public Task PutPropertyDetail(int id, PropertyDetail propertyDetail);
        public Task DeletePropertyDetail(int id);
    }
}
