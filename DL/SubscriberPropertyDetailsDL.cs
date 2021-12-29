﻿using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class SubscriberPropertyDetailsDL: ISubscriberPropertyDetailsDL
    {
        ApartmentBrokerageContext data;
        public SubscriberPropertyDetailsDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }
        public async Task PostSubscriberPropertyDetails(SubscriberPropertyDetail propertyDetail)
        {
            await data.SubscriberPropertyDetails.AddAsync(propertyDetail);
            await data.SaveChangesAsync();
        }

        public async Task<SubscriberPropertyDetail> GetPropertyDetailsBySubscriberId(int id)
        {
            return await data.SubscriberPropertyDetails.Where(property => property.SubscriptionPerUserId == id).FirstOrDefaultAsync();
        }

        public async Task PutPropertyDetails(SubscriberPropertyDetail property)
        {
            SubscriberPropertyDetail p = await data.SubscriberPropertyDetails.FindAsync(property.Id);
            data.Entry(p).CurrentValues.SetValues(property);
            await data.SaveChangesAsync();
        }
    }
}
