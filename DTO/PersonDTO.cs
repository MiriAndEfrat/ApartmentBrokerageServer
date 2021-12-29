using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public int IdentityId { get; set; }
        public int StreetId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int BuildingNumber { get; set; }
        public int Floor { get; set; }
        public int Mailbox { get; set; }
        public List<int> UserType { get; set; }
    }
}
