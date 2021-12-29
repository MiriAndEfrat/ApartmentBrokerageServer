using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserTypeDL: IUserTypeDL
    {
        ApartmentBrokerageContext data;
        public UserTypeDL(ApartmentBrokerageContext data)
        {
            this.data = data;
        }
        public async Task<List<UserType>> GetAll()
        {
            return await data.UserTypes.ToListAsync();
        }
        public async Task PostUserType(UserType userType)
        {
            await data.UserTypes.AddAsync(userType);
            await data.SaveChangesAsync();
        }
        public async Task PutUserType(UserType userType)
        {
            UserType u = await data.UserTypes.FindAsync(userType.Id);
            data.Entry(u).CurrentValues.SetValues(userType);
            await data.SaveChangesAsync();
        }
        public async Task DeleteUserType(int id)
        {
            UserType u = await data.UserTypes.FindAsync(id);
            data.UserTypes.Remove(u);
            await data.SaveChangesAsync();
        }
    }
}
