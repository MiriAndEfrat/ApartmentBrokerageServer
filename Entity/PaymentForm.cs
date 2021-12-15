using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class PaymentForm
    {
        public PaymentForm()
        {
            PaymentPerProperties = new HashSet<PaymentPerProperty>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<PaymentPerProperty> PaymentPerProperties { get; set; }
    }
}
