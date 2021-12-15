using DTO;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL:IUserDL
    {
        ApartmentBrokerageContext data;
        public UserDL(ApartmentBrokerageContext data)
        {
            this.data=data;
        }
        
    }
}
