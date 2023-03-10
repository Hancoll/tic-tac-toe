using Game.Core.Common.Models;
using Game.Core.Exceptions.Game;

namespace Game.Core;

internal static class Game
{
    private const byte GridSize = 3;

    public static void MakeMove(CellValue[,] field, byte row, byte column, CellValue cellValue)
    {
        if(row >= GridSize || column >= GridSize)
            throw new InvalidMoveException();

        if (field[row, column] != CellValue.Empty)
            throw new InvalidMoveException();

        field[row, column] = cellValue;
    }

    public static bool IsGameOver(CellValue[,] field, CellValue playerCellValue)
    {
        if (field[0, 0] == playerCellValue && field[1, 1] == playerCellValue && field[2, 2] == playerCellValue)
            return true;

        if (field[0, 2] == playerCellValue && field[1, 1] == playerCellValue && field[2, 0] == playerCellValue)
            return true;

        if (field[1, 0] == playerCellValue && field[1, 1] == playerCellValue && field[1, 2] == playerCellValue)
            return true;

        if (field[0, 1] == playerCellValue && field[1, 1] == playerCellValue && field[2, 1] == playerCellValue)
            return true;

        if (field[0, 0] == playerCellValue && field[0, 1] == playerCellValue && field[0, 2] == playerCellValue)
            return true;

        if (field[2, 0] == playerCellValue && field[2, 1] == playerCellValue && field[2, 2] == playerCellValue)
            return true;

        if (field[0, 0] == playerCellValue && field[1, 0] == playerCellValue && field[2, 0] == playerCellValue)
            return true;

        if (field[0, 2] == playerCellValue && field[1, 2] == playerCellValue && field[2, 2] == playerCellValue)
            return true;

        return false;
    }
}
