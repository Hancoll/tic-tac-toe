namespace Game.Core.Exceptions.Game;

public class PlayerHasNoMoveException : Exception
{
    public override string Message => "Player has no move.";
}
