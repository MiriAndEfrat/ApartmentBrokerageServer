using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {

        public Task PostUser(List<User> user);
        public Task PutUser(int id, List<User> user);



    }
}
