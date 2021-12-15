using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class PaymentPerProperty
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int PaymentFormId { get; set; }


        [JsonIgnore]
        public virtual PropertyDetail Apartment { get; set; }
        [JsonIgnore]
        public virtual PaymentForm PaymentForm { get; set; }
    }
}
