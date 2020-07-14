using System.Web.Http;
using TicTacToeBL.Users;
using TicTacToeEntity;
using TicTacToeInterfaces.Users;

namespace TicTacToe_1.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersBL _userBL = new UsersBL();

        /// <summary>
        /// This API will check if user is already present or not, if user is already present 
        /// then returns userId otherwise insert user to db and then return userId
        /// </summary>
        /// <param name="usersInputParams">Email of user</param>
        /// <returns>UserId:- Unique id of user</returns>
        [Route("api/users/")]
        public IHttpActionResult Post([FromBody]UsersInputParams usersInputParams)
        {
            var usersInfo = _userBL.GetUsersInfoFromEmailId(usersInputParams.EmailId);
            if(usersInfo?.EmailId != null)
            {
                return Ok(usersInfo.UserId);
            }
            var lastInsertedId = _userBL.InsertUsersInfo(usersInputParams);
            if (lastInsertedId != null && lastInsertedId > 0)
            {
                return Ok(lastInsertedId);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
