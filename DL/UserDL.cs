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
        ApartmentBrokerageContext _data;
        public UserDL(ApartmentBrokerageContext data)
        {
          _data=data;
        }

        public async Task PostUser(List<User> user)
        {
            foreach (var u in user)
            {
                await _data.Users.AddAsync(u);
            }
            await _data.SaveChangesAsync();
        }


        public async Task PutUser(int id,List<User> user)
        {
            List<User> userTypeToRemove =await _data.Users.Where(user=> user.PersonId==id).ToListAsync();
            if (userTypeToRemove != null)
            {
                foreach (var u in userTypeToRemove)
                {
                    _data.Users.Remove(u);
                }
                foreach (var u in user)
                {
                    await _data.Users.AddAsync(u);
                }

                await _data.SaveChangesAsync();
            }

        }
    }
}
