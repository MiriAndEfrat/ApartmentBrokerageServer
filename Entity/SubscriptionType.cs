using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class SubscriptionType
    {
        public SubscriptionType()
        {
            SubscriptionPerUsers = new HashSet<SubscriptionPerUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DaysNumber { get; set; }
        public int Price { get; set; }

        [JsonIgnore]
        public virtual ICollection<SubscriptionPerUser> SubscriptionPerUsers { get; set; }
    }
}
