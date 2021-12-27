using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubscriptionPerUserBL: ISubscriptionPerUserBL
    {
        ISubscriptionPerUserDL subscriptionPerUserDL;

        public SubscriptionPerUserBL(ISubscriptionPerUserDL subscriptionPerUserDL)
        {
            this.subscriptionPerUserDL = subscriptionPerUserDL;
        }

        public async Task<List<SubscriptionPerUser>> GetSubscriptionsById(int id)
        {
            return await subscriptionPerUserDL.GetSubscriptionsById(id);            
        }

        public async Task<int> PostSubscriptionPerUser(SubscriptionPerUser subscription)
        {
            return await subscriptionPerUserDL.PostSubscriptionPerUser(subscription);

        }

    }

}
