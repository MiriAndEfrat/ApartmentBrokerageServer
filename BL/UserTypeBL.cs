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
        IUserTypeDL userTypeDL;
        public UserTypeBL(IUserTypeDL userTypeDL)
        {
            this.userTypeDL = userTypeDL;
        }
        public async Task<List<UserType>> GetAll()
        {
            return await userTypeDL.GetAll();
        }
        public async Task PostUserType(UserType userType)
        {
            await userTypeDL.PostUserType(userType);
        }
        public async Task PutUserType(UserType userType)
        {
            await userTypeDL.PutUserType(userType);
        }
        public async Task DeleteUserType(int id)
        {
            await userTypeDL.DeleteUserType(id);
        }
    }
}
