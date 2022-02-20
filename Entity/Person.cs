using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Person
    {
        public Person()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public int IdentityId { get; set; }
        public int StreetId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone1 { get; set; }
        [Phone]
        public string Phone2 { get; set; }
        [Phone]
        public string Phone3 { get; set; }
        public string Fax { get; set; }
       
        public string Email { get; set; }
        public int BuildingNumber { get; set; }
        public int Floor { get; set; }
        public int Mailbox { get; set; }
        public string Salt { get; set; }

        [NotMapped]
        public string Token { get; set; }

        [JsonIgnore]
        public virtual IdentityType Identity { get; set; }

        [JsonIgnore]
        public virtual Street Street { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
