using TicTacToeEntity;
using TicTacToeEntity.Users;

namespace TicTacToeInterfaces.Users
{
    public interface IUsersBL
    {
        UsersInfo GetUsersInfoFromEmailId(string emailId);
        int? InsertUsersInfo(UsersInputParams usersInputParams);
    }
}
