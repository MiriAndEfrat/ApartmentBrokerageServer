using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubscriptionTypeBL: ISubscriptionTypeBL
    {
        ISubscriptionTypeDL _subscriptionTypeDL;
        public SubscriptionTypeBL(ISubscriptionTypeDL subscriptionTypeDL)
        {
           _subscriptionTypeDL = subscriptionTypeDL;
        }
        public async Task<List<SubscriptionType>> GetAll()
        {
            return await _subscriptionTypeDL.GetAll();
        }
        public async Task PostSubscriptionType(SubscriptionType subscriptionType)
        {
            await _subscriptionTypeDL.PostSubscriptionType(subscriptionType);
        }
        public async Task PutSubscriptionType(SubscriptionType subscriptionType)
        {
            await _subscriptionTypeDL.PutSubscriptionType(subscriptionType);
        }
        public async Task DeleteSubscriptionType(int id)
        {
            await _subscriptionTypeDL.DeleteSubscriptionType(id);
        }

    }
}
