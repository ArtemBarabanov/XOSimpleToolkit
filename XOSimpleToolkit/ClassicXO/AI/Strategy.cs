using XOSimpleToolkit.ClassicXO.Constants;
using XOSimpleToolkit.Common.Enums;
using XOSimpleToolkit.Common.Models;

namespace XOSimpleToolkit.ClassicXO.AI
{
    /// <summary>
    /// Стратегия игры компьютера
    /// </summary>
    public abstract class Strategy
    {
        /// <summary>
        /// Делает ход
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <returns>Клетка</returns>
        public abstract Cell MakeMove(Cell[,] field);

        /// <summary>
        /// Делает случайный ход
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <returns>Клетка</returns>
        protected virtual Cell RandomMove(Cell[,] field)
        {
            var emptyCells = field.Cast<Cell>()
                .Where(cell => cell.CellState == CellState.Empty)
                .ToList();
            var randomPosition = new Random().Next(emptyCells.Count);
            emptyCells[randomPosition].CellState = CellState.Computer;
            return emptyCells[randomPosition];
        }

        /// <summary>
        /// Находит выигрышную следующим ходом клетку для человека, если есть
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <returns>Выигрышная клетка</returns>
        protected virtual Cell? FindManWinCell(Cell[,] field)
        {
            return FindWinCell(field, CellState.Human);
        }

        /// <summary>
        /// Находит выигрышную следующим ходом клетку для компьютера, если есть
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <returns>Выигрышная клетка</returns>
        protected virtual Cell? FindCompWinCell(Cell[,] field)
        {
            return FindWinCell(field, CellState.Computer);
        }

        private Cell? FindWinCell(Cell[,] field, CellState interestedState) 
        {
            for (int i = 0; i < FieldConstants.FieldWidth; i++)
            {
                if (field[i, 0].CellState == interestedState 
                    && field[i, 1].CellState == interestedState 
                    && field[i, 2].CellState == CellState.Empty) { return field[i, 2]; }
                if (field[i, 0].CellState == interestedState 
                    && field[i, 1].CellState == CellState.Empty 
                    && field[i, 2].CellState == interestedState) { return field[i, 1]; }
                if (field[i, 0].CellState == CellState.Empty 
                    && field[i, 1].CellState == interestedState 
                    && field[i, 2].CellState == interestedState) { return field[i, 0]; }
                if (field[0, i].CellState == interestedState 
                    && field[1, i].CellState == interestedState 
                    && field[2, i].CellState == CellState.Empty) { return field[2, i]; }
                if (field[0, i].CellState == interestedState 
                    && field[1, i].CellState == CellState.Empty 
                    && field[2, i].CellState == interestedState) { return field[1, i]; }
                if (field[0, i].CellState == CellState.Empty 
                    && field[1, i].CellState == interestedState 
                    && field[2, i].CellState == interestedState) { return field[0, i]; }
                if (field[0, 0].CellState == interestedState 
                    && field[1, 1].CellState == interestedState 
                    && field[2, 2].CellState == CellState.Empty) { return field[2, 2]; }
                if (field[0, 0].CellState == interestedState 
                    && field[1, 1].CellState == CellState.Empty 
                    && field[2, 2].CellState == interestedState) { return field[1, 1]; }
                if (field[0, 0].CellState == CellState.Empty 
                    && field[1, 1].CellState == interestedState 
                    && field[2, 2].CellState == interestedState) { return field[0, 0]; }
                if (field[0, 2].CellState == interestedState 
                    && field[1, 1].CellState == interestedState 
                    && field[2, 0].CellState == CellState.Empty) { return field[2, 0]; }
                if (field[0, 2].CellState == interestedState 
                    && field[1, 1].CellState == CellState.Empty 
                    && field[2, 0].CellState == interestedState) { return field[1, 1]; }
                if (field[0, 2].CellState == CellState.Empty 
                    && field[1, 1].CellState == interestedState 
                    && field[2, 0].CellState == interestedState) { return field[0, 2]; }
            }
            return null;
        }
    }
}
