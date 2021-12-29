using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class SubscriptionTypeDL: ISubscriptionTypeDL
    {
        ApartmentBrokerageContext data;
        public SubscriptionTypeDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }
        public async Task<List<SubscriptionType>> GetAll()
        {
            return await data.SubscriptionTypes.ToListAsync();
        }
        public async Task PostSubscriptionType(SubscriptionType subscriptionType)
        {
            await data.SubscriptionTypes.AddAsync(subscriptionType);
            await data.SaveChangesAsync();
        }
        public async Task PutSubscriptionType(SubscriptionType subscriptionType)
        {
            SubscriptionType s=await data.SubscriptionTypes.FindAsync(subscriptionType.Id);
            data.Entry(s).CurrentValues.SetValues(subscriptionType);
            await data.SaveChangesAsync();            
        }
        public async Task DeleteSubscriptionType(int id)
        {
            SubscriptionType s = await data.SubscriptionTypes.FindAsync(id);
            data.SubscriptionTypes.Remove(s);
            await data.SaveChangesAsync();
        }
    }
}
