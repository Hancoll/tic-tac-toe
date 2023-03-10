using Game.Core.Common.Models;
using Game.Core.Services.Lobby;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Game.Api.Hubs;

public class LobbyHub : Hub
{
    private readonly ILobbyService _lobbyService;

    public Task JoinLobby(Guid lobbyId)
    {
        try
        {
            _lobbyService.JoinLobby(lobbyId, Context.ConnectionId);
            return Groups.AddToGroupAsync(Context.ConnectionId, lobbyId.ToString());
        }

        catch (Exception e)
        {
            return Clients.Caller.SendAsync("Exception", e.Message);
        }
    }

    public async Task MakeMove(Guid lobbyId, int row, int column)
    {
        try
        {
            if (_lobbyService.MakeMove(lobbyId, Context.ConnectionId, row, column, out CellValue[,] field, out CellValue? winner))
                await Clients.Groups(lobbyId.ToString()).SendAsync("GameOver", winner);

            // Copying

            CellValue[][] rows =
            {
                new CellValue[3],
                new CellValue[3],
                new CellValue[3]
            };

            for (int y = 0; y < rows.Length; y++)
            {
                for (int x = 0; x < rows[y].Length; x++)
                {
                    rows[x][y] = field[x, y];
                }
            }

            await Clients.Groups(lobbyId.ToString()).SendAsync("ReceiveField", rows);
        }

        catch (Exception e)
        {
            await Clients.Caller.SendAsync("Exceptions", e.Message);
        }
    }

    public LobbyHub(ILobbyService lobbyService)
    {
        _lobbyService = lobbyService;
    }
}
