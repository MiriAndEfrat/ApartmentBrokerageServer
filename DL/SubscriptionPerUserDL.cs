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
}
}
