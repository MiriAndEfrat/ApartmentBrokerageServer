using AutoMapper;
using DL;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class UserBL: IUserBL
    {
        IUserDL userDL;
        IPersonDL personDL;
        IMapper mapper;

        public UserBL(IUserDL userDL, IPersonDL personDL,IMapper mapper)
        {
            this.userDL = userDL;
            this.personDL = personDL;
            this.mapper = mapper;
        }

        public async Task<List<PersonDTO>> GetAll()
        {
            var people = await personDL.GetAll();
            var peopleDTO = mapper.Map<List<Person>, List<PersonDTO>>(people);
            return peopleDTO;

        }

    }
}
