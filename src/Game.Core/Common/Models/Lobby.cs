using Game.Core.Exceptions.Lobby;

namespace Game.Core.Common.Models;

internal class Lobby
{
    private string _firstPlayerId = null!;

    private string _secondPlayerId = null!;

    /// <summary>
    /// Which player should move.
    /// </summary>
    private string _playerIdMove = null!;

	public CellValue[,] Field { get; init; } = null!;

    public bool IsFull()
    {
        if (!string.IsNullOrEmpty(_firstPlayerId) && !string.IsNullOrEmpty(_secondPlayerId))
            return true;

        return false;
    }
    
    public void AddPlayer(string playerId)
    {
        if (IsFull())
            throw new LobbyIsFullException();

        if (string.IsNullOrEmpty(_firstPlayerId))
            _firstPlayerId = playerId;
        else
            _secondPlayerId = playerId;
    }

    public bool HasPlayerMove(string playerId)
    {
        if (_playerIdMove != playerId)
            return false;

        return true;
    }

    public CellValue GetPlayerCellValue(string playerId)
    {
        if (_firstPlayerId == playerId)
            return CellValue.Cross;

        return CellValue.Nought;
    }

    /// <summary>
    /// Pass the move to another player.
    /// </summary>
    public void PassMove()
    {
        if (_firstPlayerId == _playerIdMove)
            _playerIdMove = _secondPlayerId;
        else
            _playerIdMove = _firstPlayerId;
    }
}
