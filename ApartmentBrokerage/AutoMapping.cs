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
            CreateMap<Person, PersonDTO>()
            .ForMember(dest => dest.UserType,
                       opts => opts.MapFrom(src =>src.Users.Select(u=>u.UserTypeId).ToList()));
        }

        

    }
}
