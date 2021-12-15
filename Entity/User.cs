using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class User
    {
        public User()
        {
            PropertyDetails = new HashSet<PropertyDetail>();
            SubscriptionPerUsers = new HashSet<SubscriptionPerUser>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int UserTypeId { get; set; }


        [JsonIgnore]
        public virtual Person Person { get; set; }
        [JsonIgnore]
        public virtual UserType UserType { get; set; }
        [JsonIgnore]
        public virtual ICollection<PropertyDetail> PropertyDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubscriptionPerUser> SubscriptionPerUsers { get; set; }
    }
}
