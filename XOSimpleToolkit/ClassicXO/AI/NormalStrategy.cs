using XOSimpleToolkit.Common.Enums;
using XOSimpleToolkit.Common.Models;

namespace XOSimpleToolkit.ClassicXO.AI
{
    /// <summary>
    /// Стратегия среднего уровня сложности
    /// </summary>
    public class NormalStrategy : Strategy
    {
        /// <inheritdoc />
        public override Cell MakeMove(Cell[,] field)
        {
            var canManWin = FindManWinCell(field);

            if (canManWin != null)
            {
                var x = canManWin.X;
                var y = canManWin.Y;
                field[x, y].CellState = CellState.Computer;
                return canManWin;
            }
            else
            {
                return RandomMove(field);
            }
        }
    }
}
