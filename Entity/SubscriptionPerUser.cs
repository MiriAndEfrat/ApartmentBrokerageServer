using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class SubscriptionPerUser
    {
        public SubscriptionPerUser()
        {
            SubscriberPropertyDetails = new HashSet<SubscriberPropertyDetail>();
        }

        public int Id { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int AreaId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public virtual Area Area { get; set; }
        [JsonIgnore]
        public virtual SubscriptionType SubscriptionType { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubscriberPropertyDetail> SubscriberPropertyDetails { get; set; }
    }
}
