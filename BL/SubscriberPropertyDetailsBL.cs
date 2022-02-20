using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubscriberPropertyDetailsBL: ISubscriberPropertyDetailsBL
    {
        ISubscriberPropertyDetailsDL _subscriberPropertyDetailsDL;
        public SubscriberPropertyDetailsBL(ISubscriberPropertyDetailsDL subscriberPropertyDetailsDL)
        {
           _subscriberPropertyDetailsDL = subscriberPropertyDetailsDL;
        }
        
        public async Task PostSubscriberPropertyDetails(SubscriberPropertyDetail propertyDetail)
        {
            await _subscriberPropertyDetailsDL.PostSubscriberPropertyDetails(propertyDetail);
        }

        public async Task<SubscriberPropertyDetail> GetPropertyDetailsBySubscriberId(int id)
        {
            return await _subscriberPropertyDetailsDL.GetPropertyDetailsBySubscriberId(id);
        }

        public async Task PutPropertyDetails(SubscriberPropertyDetail property)
        {
            await _subscriberPropertyDetailsDL.PutPropertyDetails(property);
        }
    }
}
