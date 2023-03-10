using Game.Core.Common.Models;
using Game.Core.Exceptions.Lobby;

namespace Game.Core;

internal class LobbiesManager
{
    private Dictionary<Guid, Lobby> _lobbiesPool = new();

    public Guid CreateLobby()
    {
        var lobbyId = Guid.NewGuid();
        var lobby = new Lobby();

        _lobbiesPool.Add(lobbyId, lobby);

        return lobbyId;
    }

    public Lobby GetLobby(Guid lobbyId)
    {
        if (!_lobbiesPool.TryGetValue(lobbyId, out Lobby? lobby))
            throw new LobbyNotFoundException();

        return lobby;
    }
}
