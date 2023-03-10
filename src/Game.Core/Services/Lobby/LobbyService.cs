using Game.Core.Common.Models;
using Game.Core.Exceptions.Game;
using Game.Core.Exceptions.Lobby;

namespace Game.Core.Services.Lobby;

internal class LobbyService : ILobbyService
{
    private readonly LobbiesManager _lobbiesManager;

    public Guid CreateLobby()
    {
        return _lobbiesManager.CreateLobby();
    }

    public void JoinLobby(Guid lobbyId, string playerId)
    {
        _lobbiesManager.GetLobby(lobbyId).AddPlayer(playerId);
    }

    public bool MakeMove(Guid lobbyId, string playerId, int row, int column, out CellValue[,] field, out CellValue? winner)
    {
        var lobby = _lobbiesManager.GetLobby(lobbyId);

        if (!lobby.IsFull())
            throw new NotAllPlayersAreReadyException();

        if (lobby.HasPlayerMove(playerId))
            throw new PlayerHasNoMoveException();

        var playerCellValue = lobby.GetPlayerCellValue(playerId);

        Game.MakeMove(lobby.Field, row, column, playerCellValue);
        field = lobby.Field;

        if (Game.IsGameOver(lobby.Field, playerCellValue))
        {
            winner = playerCellValue;
            return true;
        }

        lobby.PassMove();

        winner = null;
        return false;
    }

    public LobbyService(LobbiesManager lobbiesManager)
    {
        _lobbiesManager = lobbiesManager;
    }
}
