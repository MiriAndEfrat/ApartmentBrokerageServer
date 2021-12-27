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


        public async Task PostUser(List<User> user)
        {
            foreach (var u in user)
            {
                await data.Users.AddAsync(u);
            }

            await data.SaveChangesAsync();

        }


        public async Task PutUser(int id,List<User> user)
        {
            List<User> userType =await data.Users.Where(a=>a.Id==id).ToListAsync();
            foreach (var u in userType)
            {
                data.Users.Remove(u);
            }
            foreach (var u in user)
            {
                await data.Users.AddAsync(u);               
            }

            await data.SaveChangesAsync();

        }
    }
}
