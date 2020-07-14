using TicTacToeDAL.Users;
using TicTacToeEntity;
using TicTacToeEntity.Users;
using TicTacToeInterfaces.Users;

namespace TicTacToeBL.Users
{
    public class UsersBL : IUsersBL
    {
        private readonly IUsersRepository _usersRepository = new UsersRepository();

        /// <summary>
        /// It will return userInfo from email id.
        /// </summary>
        /// <param name="emailId">Email id of user</param>
        /// <returns>UserId and EmailId of user</returns>
        public UsersInfo GetUsersInfoFromEmailId(string emailId)
        {
            return _usersRepository.GetUsersInfoFromEmailId(emailId);
        }

        /// <summary>
        /// It will insert user info into databse
        /// </summary>
        /// <param name="usersInputParams">UserInfo like emailId</param>
        /// <returns>UserId:- unique id of user</returns>
        public int? InsertUsersInfo(UsersInputParams usersInputParams)
        {
            //No need to go through cache layer as we are inserting new object(databse row) and there is nothing in cache
            //although we can go through cache layer, if we want to store object in cache as soon as we add data into database
            return _usersRepository.InsertUsersInfo(usersInputParams);
        }
    }
}
