namespace Game.Core.Exceptions.Game;

public class InvalidMoveException : Exception
{
    public override string Message => "Invalid move.";
}
