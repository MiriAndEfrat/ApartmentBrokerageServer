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
        ApartmentBrokerageContext _data;
        public UserTypeDL(ApartmentBrokerageContext data)
        {
            _data = data;
        }
        public async Task<List<UserType>> GetAll()
        {
            return await _data.UserTypes.ToListAsync();
        }
        public async Task PostUserType(UserType userType)
        {
            await _data.UserTypes.AddAsync(userType);
            await _data.SaveChangesAsync();
        }
        public async Task PutUserType(UserType userType)
        {
            UserType u = await _data.UserTypes.FindAsync(userType.Id);
            if (u != null)
            {
                _data.Entry(u).CurrentValues.SetValues(userType);
                await _data.SaveChangesAsync();
            }
        }
        public async Task DeleteUserType(int id)
        {
            UserType u = await _data.UserTypes.FindAsync(id);
            if (u != null)
            {
                _data.UserTypes.Remove(u);
                await _data.SaveChangesAsync();
            }
        }
    }
}
