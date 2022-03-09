using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface ISubscriptionPerUserDL
    {
        public Task<List<SubscriptionPerUser>> GetSubscriptionsById(int id);
        public Task<int> PostSubscriptionPerUser(SubscriptionPerUser subscription);
        public Task PutSubscriptionPerUser(SubscriptionPerUser subscription);
        

     }
}
