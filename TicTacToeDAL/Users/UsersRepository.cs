using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using TicTacToeEntity;
using TicTacToeEntity.Users;
using TicTacToeInterfaces.Users;

namespace TicTacToeDAL.Users
{

    public class UsersRepository : IUsersRepository
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        public UsersInfo GetUsersInfo(int userId)
        {
            string query = $@"select *
                              from Users
                              where userId = @v_userId;";
            var dbParams = GetDbParamsFromUserId(userId);
            using (var connection = new SQLiteConnection(_connString))
            {
                return connection.Query<UsersInfo>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
        }

        public UsersInfo GetUsersInfoFromEmailId(string emailId)
        {
            string query = $@"select *
                              from Users
                              where emailId = @v_emailId;";
            var dbParams = GetDbParamsFromEmailId(emailId);
            using (var connection = new SQLiteConnection(_connString))
            {
                return connection.Query<UsersInfo>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
        }

        public int? InsertUsersInfo(UsersInputParams usersInputParams)
        {
            int? lastInsertedId = -1;
            string query = $@"insert into Users (EmailId)
                                          values (@v_emailId);
                              select last_insert_rowid();";
            var dbParams = GetDbParamsFromEmailId(usersInputParams.EmailId);
            using (var connection = new SQLiteConnection(_connString))
            {
                lastInsertedId = connection.Query<int>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
            return lastInsertedId;
        }

        private object GetDbParamsFromEmailId(string emailId)
        {
            return new
            {
                v_emailId = emailId
            };
        }

        private object GetDbParamsFromUserId(int userId)
        {
            return new
            {
                v_userId = userId
            };
        }
    }
}
