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
        ApartmentBrokerageContext data;

        public SubscriptionPerUserDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }

        public async Task<List<SubscriptionPerUser>> GetSubscriptionsById(int id)
        {
            return await data.SubscriptionPerUsers.Where(s => s.UserId == id).ToListAsync();
        }

        public async Task<int> PostSubscriptionPerUser(SubscriptionPerUser subscription)
        {
            await data.SubscriptionPerUsers.AddAsync(subscription);
            await data.SaveChangesAsync();
            var s = await data.SubscriptionPerUsers.MaxAsync(s => s.Id);
            return s;
        }

    }
}
