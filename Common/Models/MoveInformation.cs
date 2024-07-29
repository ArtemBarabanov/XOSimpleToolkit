using XOSimpleToolkit.Common.Enums;

namespace XOSimpleToolkit.Common.Models
{
    /// <summary>
    /// Информация о ходе
    /// </summary>
    public class MoveInformation
    {
        /// <summary>
        /// Координата X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Кто ходил первым (вспомогательная информация для определения, крестиком или ноликом ходит играющий)
        /// </summary>
        public Turn WhoWasFirst { get; set; }
    }
}
