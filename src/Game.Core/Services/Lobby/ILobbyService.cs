using Game.Core.Common.Models;

namespace Game.Core.Services.Lobby;

public interface ILobbyService
{
    Guid CreateLobby();

    void JoinLobby(Guid lobbyId, string playerId);

    /// <returns>Returns true if player win.</returns>
    bool MakeMove(Guid lobbyId, string playerId, byte row, byte column, out CellValue[,] field, out CellValue? winner);
}
