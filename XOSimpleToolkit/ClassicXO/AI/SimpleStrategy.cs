using XOSimpleToolkit.Common.Models;

namespace XOSimpleToolkit.ClassicXO.AI
{
    /// <summary>
    /// Стратегия лекого уровня сложности
    /// </summary>
    public class SimpleStrategy : Strategy
    {
        /// <inheritdoc />
        public override Cell MakeMove(Cell[,] field)
        {
            return RandomMove(field);
        }
    }
}
