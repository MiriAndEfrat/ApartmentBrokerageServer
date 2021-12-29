using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ISubscriberPropertyDetailsBL
    {
        public Task PostSubscriberPropertyDetails(SubscriberPropertyDetail propertyDetail);
        public Task<SubscriberPropertyDetail> GetPropertyDetailsBySubscriberId(int id);
        public Task PutPropertyDetails(SubscriberPropertyDetail property);



    }
}
