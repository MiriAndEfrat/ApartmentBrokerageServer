using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class SubscriberPropertyDetail
    {
        public int Id { get; set; }
        public int SubscriptionPerUserId { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? CityId { get; set; }
        public int? NeighborhoodId { get; set; }
        public int? StatusId { get; set; }
        public int? RoomNumber { get; set; }
        public int? Floor { get; set; }
        public int? MaximumPrice { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? SquareMeter { get; set; }
        public int? SeveralDirectionsOfAir { get; set; }
        public bool? Elevators { get; set; }
        public bool? Renovated { get; set; }
        public bool? AccessForDisabled { get; set; }
        public bool? Furnished { get; set; }
        public bool? Parking { get; set; }
        public bool? Storage { get; set; }
        public bool? AirConditioning { get; set; }
        public bool? Yard { get; set; }
        public bool? Porch { get; set; }
        public int? Distance { get; set; }


        [JsonIgnore]
        public virtual City City { get; set; }
        [JsonIgnore]
        public virtual Neighborhood Neighborhood { get; set; }
        [JsonIgnore]
        public virtual PropertyType PropertyType { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual SubscriptionPerUser SubscriptionPerUser { get; set; }
    }
}
