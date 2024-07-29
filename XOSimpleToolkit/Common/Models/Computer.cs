using XOSimpleToolkit.ClassicXO.AI;

namespace XOSimpleToolkit.Common.Models
{
    /// <summary>
    /// Компьютерный игрок
    /// </summary>
    public class Computer
    {
        /// <summary>
        /// Стратегия игры компьютера
        /// </summary>
        public Strategy CurrentStrategy { get; }

        private Cell[,] _field;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Strategy">Стратегия</param>
        /// <param name="field">Игровое поле</param>
        public Computer(Strategy Strategy, Cell[,] field)
        {
            CurrentStrategy = Strategy;
            _field = field;
        }

        /// <summary>
        /// Делает ход
        /// </summary>
        /// <returns>Клетка</returns>
        public virtual Cell? MakeMove()
        {
            return CurrentStrategy.MakeMove(_field);
        }
    }
}
