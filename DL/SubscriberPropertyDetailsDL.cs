using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class SubscriberPropertyDetailsDL: ISubscriberPropertyDetailsDL
    {
        ApartmentBrokerageContext _data;
        public SubscriberPropertyDetailsDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }
        public async Task PostSubscriberPropertyDetails(SubscriberPropertyDetail propertyDetail)
        {
            await _data.SubscriberPropertyDetails.AddAsync(propertyDetail);
            await _data.SaveChangesAsync();
        }

        public async Task<SubscriberPropertyDetail> GetPropertyDetailsBySubscriberId(int id)
        {
            return await _data.SubscriberPropertyDetails.Where(property => property.SubscriptionPerUserId == id).FirstOrDefaultAsync();
        }

        public async Task PutPropertyDetails(SubscriberPropertyDetail property)
        {
            SubscriberPropertyDetail p = await _data.SubscriberPropertyDetails.FindAsync(property.Id);
            if (p != null)
            {
                _data.Entry(p).CurrentValues.SetValues(property);
                await _data.SaveChangesAsync();
            }
        }
    }
}
