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
        ISubscriberPropertyDetailsDL subscriberPropertyDetailsDL;
        public SubscriberPropertyDetailsBL(ISubscriberPropertyDetailsDL subscriberPropertyDetailsDL)
        {
            this.subscriberPropertyDetailsDL = subscriberPropertyDetailsDL;
        }
        
        public async Task PostSubscriberPropertyDetails(SubscriberPropertyDetail propertyDetail)
        {
            await subscriberPropertyDetailsDL.PostSubscriberPropertyDetails(propertyDetail);
        }

        public async Task<SubscriberPropertyDetail> GetPropertyDetailsBySubscriberId(int id)
        {
            return await subscriberPropertyDetailsDL.GetPropertyDetailsBySubscriberId(id);
        }

        public async Task PutPropertyDetails(SubscriberPropertyDetail property)
        {
            await subscriberPropertyDetailsDL.PutPropertyDetails(property);
        }
    }
}
