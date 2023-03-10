using Game.Core.Services.Lobby;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly ILobbyService _lobbyService;

        [HttpPost("Create")]
        public IActionResult Create()
        {
            var lobbyId = _lobbyService.CreateLobby();

            return Ok(lobbyId);
        }

        public LobbyController(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }
    }
}
