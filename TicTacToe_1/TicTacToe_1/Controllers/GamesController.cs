using System.Web.Http;
using TicTacToeBL.Games;
using TicTacToeEntity.Games;
using TicTacToeEntity.Validators;
using TicTacToeInterfaces.Games;

namespace TicTacToe_1.Controllers
{
    public class GamesController : ApiController
    {
        private readonly IGamesBL _gamesBL = new GamesBL();
        private readonly IMovesBL _movesBL = new MovesBL();

        /// <summary>
        /// This API will give gamesInfo based on gameId provided.
        /// </summary>
        /// <param name="gameId">UnquiId of game</param>
        /// <returns>Details info of game</returns>
        // GET: api/Games/5
        [Route("api/games/{gameId}")]
        public IHttpActionResult Get(int gameId)
        {
            if (gameId <= 0)
            {
                return BadRequest("GameId must be greater then 0.");
            }
            var gamesInfo = _gamesBL.GetGamesInfo(gameId);
            return Ok(gamesInfo);
        }

        /// <summary>
        /// It will update user in game. If new user comes it will create new game or if some one is already
        /// waiting then it will update the game info by assigning 2nd user to it.
        /// </summary>
        /// <param name="gamesInputParams">Unique Id of user</param>
        /// <returns>GameId: Unique id of game</returns>
        // POST: api/Games
        [Route("api/games/")]
        public IHttpActionResult UpdateUser([FromBody]GamesInputParams gamesInputParams)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gameId = _gamesBL.UpsertUser(gamesInputParams.UserId);
            if (gameId != null && gameId > 0)
            {
                return Ok(gameId);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// It will update the games info table with winner given in the input.
        /// </summary>
        /// <param name="gameId">Unique Id of game</param>
        /// <param name="gamesInputParams">Unique Id of user</param>
        /// <returns>Message: Success</returns>
        [Route("api/games/{gameId}/winner")]
        public IHttpActionResult UpdateWinner(int gameId, [FromBody]GamesInputParams gamesInputParams)
        {
            // Validation starts here
            if (gameId <= 0)
            {
                return BadRequest("GameId must be greater then 0.");
            }
            else if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Validation ends here
            var isSuccess = _gamesBL.UpdateWinner(gameId, gamesInputParams.UserId);
            if (isSuccess)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// It will provide all the moves played by users based on game Id.
        /// </summary>
        /// <param name="gameId">Unique Id of game</param>
        /// <returns>List of moves played by user</returns>
        [Route("api/games/{gameId}/moves")]
        public IHttpActionResult GetMovesInfo(int gameId)
        {
            if(gameId <= 0)
            {
                return BadRequest("GameId must be greater then 0.");
            }
            var gamesInfo = _movesBL.GetMovesInfo(gameId);
            return Ok(gamesInfo);
        }

        /// <summary>
        /// It will insert moves played by user in table
        /// </summary>
        /// <param name="gameId">Uniqie Id of game</param>
        /// <param name="movesInfo">Moves info like rowNUmber, colNumber and etc</param>
        /// <returns></returns>
        [Route("api/games/{gameId}/moves")]
        public IHttpActionResult InsertMove(int gameId, [FromBody]MovesInfo movesInfo)
        {
            // Validation starts here
            movesInfo.GameId = gameId;
            var validator = new MovesInfoValidator();
            var results = validator.Validate(movesInfo);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Validation ends here

            _movesBL.InsertMovesInfo(gameId, movesInfo);
            return Ok("Success");
        }
    }
}
