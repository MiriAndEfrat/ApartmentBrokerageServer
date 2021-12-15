using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Street
    {
        public Street()
        {
            People = new HashSet<Person>();
            PropertyDetails = new HashSet<PropertyDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int? NeighborhoodId { get; set; }


        [JsonIgnore]
        public virtual City City { get; set; }
        [JsonIgnore]
        public virtual Neighborhood Neighborhood { get; set; }
        [JsonIgnore]
        public virtual ICollection<Person> People { get; set; }
        [JsonIgnore]
        public virtual ICollection<PropertyDetail> PropertyDetails { get; set; }
    }
}
