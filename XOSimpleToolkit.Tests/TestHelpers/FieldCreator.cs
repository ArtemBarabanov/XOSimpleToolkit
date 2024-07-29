using XOSimpleToolkit.ClassicXO.Constants;
using XOSimpleToolkit.Common.Enums;
using XOSimpleToolkit.Common.Models;

namespace XOSimpleToolkit.Tests.TestHelpers
{
    /// <summary>
    /// Вспомогательный класс для создания игровых полей
    /// </summary>
    public class FieldCreator
    {
        /// <summary>
        /// Создает игровое поле, где игрок побеждает следующим шагом
        /// </summary>
        /// <returns>Игровое поле</returns>
        public static Cell[,] HumanAlmostWinField() 
        {
            var field = new Cell[FieldConstants.FieldWidth, FieldConstants.FieldHeight];
            for (var i = 0; i < FieldConstants.FieldWidth; i++) 
            {
                for (var j = 0; j < FieldConstants.FieldHeight; j++) 
                {
                    field[i, j] = new Cell(i, j, CellState.Empty);
                }
            }

            field[0, 0].CellState = CellState.Human;
            field[1, 1].CellState = CellState.Human;

            return field;
        }

        /// <summary>
        /// Создает игровое поле, где компьютер побеждает следующим шагом
        /// </summary>
        /// <returns>Игровое поле</returns>
        public static Cell[,] ComputerAlmostWinField()
        {
            var field = new Cell[FieldConstants.FieldWidth, FieldConstants.FieldHeight];
            for (var i = 0; i < FieldConstants.FieldWidth; i++)
            {
                for (var j = 0; j < FieldConstants.FieldHeight; j++)
                {
                    field[i, j] = new Cell(i, j, CellState.Empty);
                }
            }

            field[2, 0].CellState = CellState.Computer;
            field[2, 2].CellState = CellState.Computer;

            return field;
        }

        /// <summary>
        /// Создает игровое поле, где компьютер или игрок побеждают следующим шагом
        /// </summary>
        /// <returns>Игровое поле</returns>
        public static Cell[,] HumanAndComputerAlmostWinField()
        {
            var field = new Cell[FieldConstants.FieldWidth, FieldConstants.FieldHeight];
            for (var i = 0; i < FieldConstants.FieldWidth; i++)
            {
                for (var j = 0; j < FieldConstants.FieldHeight; j++)
                {
                    field[i, j] = new Cell(i, j, CellState.Empty);
                }
            }

            field[0, 0].CellState = CellState.Computer;
            field[0, 1].CellState = CellState.Computer;

            field[2, 0].CellState = CellState.Human;
            field[2, 1].CellState = CellState.Human;

            return field;
        }
    }
}
