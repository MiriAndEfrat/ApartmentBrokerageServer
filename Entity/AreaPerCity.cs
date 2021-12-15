using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class AreaPerCity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }

        [JsonIgnore]
        public virtual Area Area { get; set; }
        [JsonIgnore]
        public virtual City City { get; set; }
    }
}
