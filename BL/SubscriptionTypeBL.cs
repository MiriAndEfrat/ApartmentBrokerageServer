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
        ISubscriptionTypeDL subscriptionTypeDL;
        public SubscriptionTypeBL(ISubscriptionTypeDL subscriptionTypeDL)
        {
            this.subscriptionTypeDL = subscriptionTypeDL;
        }
        public async Task<List<SubscriptionType>> GetAll()
        {
            return await subscriptionTypeDL.GetAll();
        }
        public async Task PostSubscriptionType(SubscriptionType subscriptionType)
        {
            await subscriptionTypeDL.PostSubscriptionType(subscriptionType);
        }
        public async Task PutSubscriptionType(SubscriptionType subscriptionType)
        {
            await subscriptionTypeDL.PutSubscriptionType(subscriptionType);
        }
        public async Task DeleteSubscriptionType(int id)
        {
            await subscriptionTypeDL.DeleteSubscriptionType(id);
        }

    }
}
