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
        ISubscriptionPerUserDL _subscriptionPerUserDL;

        public SubscriptionPerUserBL(ISubscriptionPerUserDL subscriptionPerUserDL)
        {
           _subscriptionPerUserDL = subscriptionPerUserDL;
        }

        public async Task<List<SubscriptionPerUser>> GetSubscriptionsById(int id)
        {
            return await _subscriptionPerUserDL.GetSubscriptionsById(id);            
        }

        public async Task<int> PostSubscriptionPerUser(SubscriptionPerUser subscription)
        {
            return await _subscriptionPerUserDL.PostSubscriptionPerUser(subscription);
        }

    }

}
