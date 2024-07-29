using XOSimpleToolkit.Common.Enums;

namespace XOSimpleToolkit.Common.Models
{
    /// <summary>
    /// Информация о победе
    /// </summary>
    public class VictoryInformation
    {
        /// <summary>
        /// Выигрышная комбинация
        /// </summary>
        public IEnumerable<Cell> VictoryCombinationCells { get; set; } = default!;

        /// <summary>
        /// Кто ходил первым (вспомогательная информация для определения, крестиком или ноликом ходит играющий)
        /// </summary>
        public Turn WhoWasFirst { get; set; }
    }
}
