using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeDAL.Users;
using TicTacToeEntity;
using TicTacToeEntity.Users;
using TicTacToeInterfaces.Users;

namespace TicTacToeBL.Users
{
    public class UsersBL : IUsersBL
    {
        private readonly IUsersRepository _usersRepository = new UsersRepository();

        public UsersInfo GetUsersInfoFromEmailId(string emailId)
        {
            //No need to go through cache layer as we are inserting new object(databse row) and there is nothing in cache
            //although we can go through cache layer, if we want to store object in cache as soon as we add data into database
            return _usersRepository.GetUsersInfoFromEmailId(emailId);
        }

        public int? InsertUsersInfo(UsersInputParams usersInputParams)
        {
            //No need to go through cache layer as we are inserting new object(databse row) and there is nothing in cache
            //although we can go through cache layer, if we want to store object in cache as soon as we add data into database
            return _usersRepository.InsertUsersInfo(usersInputParams);
        }
    }
}
