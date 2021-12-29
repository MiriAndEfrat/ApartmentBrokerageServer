using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ISubscriptionTypeBL
    {
        public Task<List<SubscriptionType>> GetAll();
        public Task PostSubscriptionType(SubscriptionType subscriptionType);
        public Task PutSubscriptionType(SubscriptionType subscriptionType);
        public Task DeleteSubscriptionType(int id);




    }
}
