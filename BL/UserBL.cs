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

        public UserBL(IUserDL userDL, IPersonDL personDL)
        {
            this.userDL = userDL;
            this.personDL = personDL;
        }

        public async Task<List<Person>> GetAll()
        {
            return await personDL.GetAll();
        }


        public async Task<Person> GetById(int id)
        {
            return await personDL.GetById(id);
            
        }

        public async Task<Person> GetByIdNumberAndPassword(int identity_number, string password)
        {
            return await personDL.GetByIdNumberAndPassword(identity_number,password);
        }

        public async Task PostUser(Person person,List<int> userType)
        {
            Person p=await personDL.PostPerson(person);

            List<User> user = new List<User>();
            foreach (var i in userType)
            {
                user.Add(new User { PersonId = p.Id, UserTypeId = i });
            }


            await userDL.PostUser(user);


        }

        public async Task PutUser(int id,Person person, List<User> userType)
        {

            await personDL.PutPerson(id,person);
            await userDL.PutUser(id,userType);

        }

    }
}
