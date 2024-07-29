using XOSimpleToolkit.Common.Enums;

namespace XOSimpleToolkit.Common.Models
{
    /// <summary>
    /// Игровая клетка
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Состояние клетки
        /// </summary>
        public CellState CellState { get; set; }

        /// <summary>
        /// Координата X
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="cellState">Состояние</param>
        public Cell(int x, int y, CellState cellState)
        {
            X = x;
            Y = y;
            CellState = cellState;
        }
    }
}
