using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Area
    {
        public Area()
        {
            AreaPerCities = new HashSet<AreaPerCity>();
            SubscriptionPerUsers = new HashSet<SubscriptionPerUser>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<AreaPerCity> AreaPerCities { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubscriptionPerUser> SubscriptionPerUsers { get; set; }
    }
}
