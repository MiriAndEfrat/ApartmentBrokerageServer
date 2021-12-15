using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class PropertyDetail
    {
        public PropertyDetail()
        {
            PaymentPerProperties = new HashSet<PaymentPerProperty>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public int UserPropertyNumber { get; set; }
        public int UserId { get; set; }
        public int StreetId { get; set; }
        public int PropertyTypeId { get; set; }
        public int BuildingNumber { get; set; }
        public int PropertyNumber { get; set; }
        public int Floor { get; set; }
        public int NumberRoom { get; set; }
        public int SquareMeter { get; set; }
        public int SeveralDirectionsOfAir { get; set; }
        public int Price { get; set; }
        public int StatusId { get; set; }
        public int PropertyTaxPrice { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Elevators { get; set; }
        public bool Renovated { get; set; }
        public bool AccessForDisabled { get; set; }
        public bool Parking { get; set; }
        public bool Storage { get; set; }
        public bool Furnished { get; set; }
        public bool AirConditioning { get; set; }
        public bool Yard { get; set; }
        public bool Porch { get; set; }
        public bool Available { get; set; }
        public string FreeDescription { get; set; }


        [JsonIgnore]
        public virtual PropertyType PropertyType { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Street Street { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<PaymentPerProperty> PaymentPerProperties { get; set; }
    }
}
