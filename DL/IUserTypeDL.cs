﻿using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserTypeDL
    {
        public Task<List<UserType>> GetAll();
        public Task PostUserType(UserType userType);
        public Task PutUserType(UserType userType);
        public Task DeleteUserType(int id);
    }
}