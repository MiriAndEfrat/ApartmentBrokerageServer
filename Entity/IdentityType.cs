using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class IdentityType
    {
        public IdentityType()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Person> People { get; set; }
    }
}
