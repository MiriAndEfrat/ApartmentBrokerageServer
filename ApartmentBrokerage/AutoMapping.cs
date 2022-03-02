using AutoMapper;
using Entity;
using DTO;
using System;        
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentBrokerage
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            //CreateMap<Person, PersonDTO>()
            //.ForMember(dest => dest.UserType,
            //           opts => opts.MapFrom(src => src.Users.Where(u=>u.PersonId==src.Id).Select(u => u.UserTypeId).ToList())).ReverseMap();

            CreateMap<Person, PersonDTO>()
            .ForMember(dest => dest.UserType,
                       opts => opts.MapFrom(src => src.Users.Select(u => u.UserTypeId).ToList())).ReverseMap();

            //CreateMap<PersonDTO, Person>()
            //.ForMember(dest => dest.UserType,
            //           opts => opts.MapFrom(src => src.Users.Select(u => u.UserTypeId).ToList())).ReverseMap();

            CreateMap<SubscriptionPerUser, SubscriptionAndPropertyDetailsDTO>()
            .ForMember(dest => dest.SubscriptionPerUserId,
                       opts => opts.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<SubscriberPropertyDetail, SubscriptionAndPropertyDetailsDTO>()
            .ForMember(dest => dest.SubscriberPropertyDetailId,
                       opts => opts.MapFrom(src => src.Id)).ReverseMap();
        }

        

    }
}
