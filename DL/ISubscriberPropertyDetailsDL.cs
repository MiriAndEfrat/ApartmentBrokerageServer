using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface ISubscriberPropertyDetailsDL
    {
        public Task PostSubscriberPropertyDetails(SubscriberPropertyDetail propertyDetail);
        public Task<SubscriberPropertyDetail> GetPropertyDetailsBySubscriberId(int id);


    }

}
