using XOSimpleToolkit.Common.Enums;

namespace XOSimpleToolkit.Common.Models
{
    /// <summary>
    /// Игрок человек
    /// </summary>
    public class Human
    {
        /// <summary>
        /// Делает ход
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <returns>Клетка</returns>
        public virtual Cell? MakeMove(Cell[,] field, int x, int y)
        {
            if (field[x, y].CellState == CellState.Empty)
            {
                field[x, y].CellState = CellState.Human;
                return field[x, y];
            }
            return null;
        }
    }
}
