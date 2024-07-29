using XOSimpleToolkit.Common.Enums;
using XOSimpleToolkit.Common.Models;

namespace XOSimpleToolkit.Common.Interfaces
{
    /// <summary>
    /// Интерфейс игровой сессии
    /// </summary>
    public interface IXOSession
    {
        /// <summary>
        /// Задает начальные параметры игровой сессии
        /// </summary>
        /// <param name="difficulty">Сложность</param>
        /// <param name="first">Кто ходит первым</param>
        void Start(Difficulty difficulty, Turn first);

        /// <summary>
        /// Делает ход
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        void Move(int x, int y);

        /// <summary>
        /// Событие - человек сделал ход
        /// </summary>
        event Action<MoveInformation>? HumanMoveEvent;

        /// <summary>
        /// Событие - компьютер сделал ход
        /// </summary>
        event Action<MoveInformation>? ComputerMoveEvent;

        /// <summary>
        /// Событие - человек победил
        /// </summary>
        event Action<VictoryInformation>? HumanVictoryEvent;

        /// <summary>
        /// Событие - компьютер победил
        /// </summary>
        event Action<VictoryInformation>? ComputerVictoryEvent;

        /// <summary>
        /// Событие - ничья
        /// </summary>
        event Action? DrawVictoryEvent;
    }
}
