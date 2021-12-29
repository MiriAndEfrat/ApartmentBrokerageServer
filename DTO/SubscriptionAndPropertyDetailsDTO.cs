using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SubscriptionAndPropertyDetailsDTO
    {
        //SubscriptionPerUser
        public int SubscriptionPerUserId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int AreaId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
        //SubscriberPropertyDetail    
        public int SubscriberPropertyDetailId { get; set; }
        //public int SubscriptionPerUserId { get; set; }
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
    }
}
