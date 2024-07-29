using XOSimpleToolkit.Common.Enums;
using XOSimpleToolkit.Common.Models;

namespace XOSimpleToolkit.ClassicXO.AI
{
    /// <summary>
    /// Стратегия сложного уровня сложности
    /// </summary>
    public class CleverStrategy : Strategy
    {
        /// <inheritdoc />
        public override Cell MakeMove(Cell[,] field)
        {
            var manWinCell = FindManWinCell(field);
            var compWinCell = FindCompWinCell(field);
            int x = 0;
            int y = 0;

            if (compWinCell != null)
            {
                x = compWinCell.X;
                y = compWinCell.Y;
                field[x, y].CellState = CellState.Computer;
                return compWinCell;
            }
            else if (manWinCell != null)
            {
                x = manWinCell.X;
                y = manWinCell.Y;
                field[x, y].CellState = CellState.Computer;
                return manWinCell;
            }

            return RandomMove(field);
        }
    }
}
