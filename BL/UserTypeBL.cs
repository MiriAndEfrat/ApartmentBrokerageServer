using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserTypeBL: IUserTypeBL
    {
        IUserTypeDL _userTypeDL;
        public UserTypeBL(IUserTypeDL userTypeDL)
        {
            _userTypeDL = userTypeDL;
        }
        public async Task<List<UserType>> GetAll()
        {
            return await _userTypeDL.GetAll();
        }
        public async Task PostUserType(UserType userType)
        {
            await _userTypeDL.PostUserType(userType);
        }
        public async Task PutUserType(UserType userType)
        {
            await _userTypeDL.PutUserType(userType);
        }
        public async Task DeleteUserType(int id)
        {
            await _userTypeDL.DeleteUserType(id);
        }
    }
}
