using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Neighborhood
    {
        public Neighborhood()
        {
            Streets = new HashSet<Street>();
            SubscriberPropertyDetails = new HashSet<SubscriberPropertyDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }


        [JsonIgnore]
        public virtual City City { get; set; }
        [JsonIgnore]
        public virtual ICollection<Street> Streets { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubscriberPropertyDetail> SubscriberPropertyDetails { get; set; }
    }
}
