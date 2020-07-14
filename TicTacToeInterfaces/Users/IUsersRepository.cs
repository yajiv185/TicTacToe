using TicTacToeEntity;
using TicTacToeEntity.Users;

namespace TicTacToeInterfaces.Users
{
    public interface IUsersRepository
    {
        UsersInfo GetUsersInfo(int userId);
        UsersInfo GetUsersInfoFromEmailId(string emailId);
        int? InsertUsersInfo(UsersInputParams usersInputParams);
    }
}
