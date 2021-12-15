using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class PropertyType
    {
        public PropertyType()
        {
            PropertyDetails = new HashSet<PropertyDetail>();
            SubscriberPropertyDetails = new HashSet<SubscriberPropertyDetail>();
        }

        public int Id { get; set; }
        public string Description { get; set; }


        [JsonIgnore]
        public virtual ICollection<PropertyDetail> PropertyDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubscriberPropertyDetail> SubscriberPropertyDetails { get; set; }
    }
}
