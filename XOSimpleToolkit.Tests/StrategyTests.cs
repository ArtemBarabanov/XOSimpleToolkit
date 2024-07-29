using XOSimpleToolkit.ClassicXO.AI;
using XOSimpleToolkit.Tests.TestHelpers;

namespace XOSimpleToolkit.Tests
{
    internal class StrategyTests
    {
        [Test]
        public void NormalStrategyMakeMove_HumanAlmostWin()
        {
            (int x, int y) = (2, 2);
            var field = FieldCreator.HumanAlmostWinField();
            var strategy = new NormalStrategy();

            var cell = strategy.MakeMove(field);

            Assert.That(cell.X, Is.EqualTo(x), $"Некорректная координата X для уровня сложности Средний - {cell.X}");
            Assert.That(cell.Y, Is.EqualTo(y), $"Некорректная координата Y для уровня сложности Средний - {cell.Y}");
        }

        [Test]
        public void NormalStrategyMakeMove_HumanAndComputerAlmostWin()
        {
            (int x, int y) = (2, 2);
            var field = FieldCreator.HumanAndComputerAlmostWinField();
            var strategy = new NormalStrategy();

            var cell = strategy.MakeMove(field);

            Assert.That(cell.X, Is.EqualTo(x), $"Некорректная координата X для уровня сложности Средний - {cell.X}");
            Assert.That(cell.Y, Is.EqualTo(y), $"Некорректная координата Y для уровня сложности Средний - {cell.Y}");
        }

        [Test]
        public void CleverStrategyMakeMove_ComputerAlmostWin()
        {
            (int x, int y) = (2, 1);
            var field = FieldCreator.ComputerAlmostWinField();
            var strategy = new CleverStrategy();

            var cell = strategy.MakeMove(field);

            Assert.That(cell.X, Is.EqualTo(x), $"Некорректная координата X для уровня сложности Тяжело - {cell.X}");
            Assert.That(cell.Y, Is.EqualTo(y), $"Некорректная координата Y для уровня сложности Тяжело - {cell.Y}");
        }

        [Test]
        public void CleverStrategyMakeMove_HumanAndComputerAlmostWin()
        {
            (int x, int y) = (0, 2);
            var field = FieldCreator.HumanAndComputerAlmostWinField();
            var strategy = new CleverStrategy();

            var cell = strategy.MakeMove(field);

            Assert.That(cell.X, Is.EqualTo(x), $"Некорректная координата X для уровня сложности Тяжело - {cell.X}");
            Assert.That(cell.Y, Is.EqualTo(y), $"Некорректная координата Y для уровня сложности Тяжело - {cell.Y}");
        }
    }
}
