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
            await _data.SubscriptionPerUsers.AddAsync(subscription);
            await _data.SaveChangesAsync();
            var s = await _data.SubscriptionPerUsers.MaxAsync(s => s.Id);
            return s;
        }

    }
}
