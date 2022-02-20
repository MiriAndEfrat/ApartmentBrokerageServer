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
        ApartmentBrokerageContext _data;
        public SubscriptionTypeDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }
        public async Task<List<SubscriptionType>> GetAll()
        {
            return await _data.SubscriptionTypes.ToListAsync();
        }
        public async Task PostSubscriptionType(SubscriptionType subscriptionType)
        {
            await _data.SubscriptionTypes.AddAsync(subscriptionType);
            await _data.SaveChangesAsync();
        }
        public async Task PutSubscriptionType(SubscriptionType subscriptionType)
        {
            SubscriptionType s=await _data.SubscriptionTypes.FindAsync(subscriptionType.Id);
            if (s != null)
            {
                _data.Entry(s).CurrentValues.SetValues(subscriptionType);
                await _data.SaveChangesAsync();
            }
        }
        public async Task DeleteSubscriptionType(int id)
        {
            SubscriptionType s = await _data.SubscriptionTypes.FindAsync(id);
            if (s != null)
            {
                _data.SubscriptionTypes.Remove(s);
                await _data.SaveChangesAsync();
            }
        }
    }
}
