using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class City
    {
        public City()
        {
            AreaPerCities = new HashSet<AreaPerCity>();
            Neighborhoods = new HashSet<Neighborhood>();
            Streets = new HashSet<Street>();
            SubscriberPropertyDetails = new HashSet<SubscriberPropertyDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<AreaPerCity> AreaPerCities { get; set; }
        [JsonIgnore]
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
        [JsonIgnore]
        public virtual ICollection<Street> Streets { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubscriberPropertyDetail> SubscriberPropertyDetails { get; set; }
    }
}
