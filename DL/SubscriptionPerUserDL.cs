using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class SubscriptionPerUserDL: ISubscriptionPerUserDL
    {
        ApartmentBrokerageContext _data;

        public SubscriptionPerUserDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }

        public async Task<List<SubscriptionPerUser>> GetSubscriptionsById(int id)
        {
            return await _data.SubscriptionPerUsers.Where(s => s.UserId == id).ToListAsync();
        }

        public async Task<int> PostSubscriptionPerUser(SubscriptionPerUser subscription)
        {
            SubscriptionType subscriptionType = await _data.SubscriptionTypes.FindAsync(subscription.SubscriptionTypeId);
            subscription.EndDate = subscription.StartDate.AddDays(subscriptionType.DaysNumber);

            await _data.SubscriptionPerUsers.AddAsync(subscription);
            await _data.SaveChangesAsync();
            var s = await _data.SubscriptionPerUsers.MaxAsync(s => s.Id);
            return s;
        }

        public async Task PutSubscriptionPerUser(SubscriptionPerUser subscription)
        {
            SubscriptionType subscriptionType = await _data.SubscriptionTypes.FindAsync(subscription.SubscriptionTypeId);
            subscription.EndDate = subscription.StartDate.AddDays(subscriptionType.DaysNumber);

            SubscriptionPerUser s = await _data.SubscriptionPerUsers.FindAsync(subscription.Id);
            if (s != null)
            {
                _data.Entry(s).CurrentValues.SetValues(subscription);
                await _data.SaveChangesAsync();
            }
        }
    }
}
