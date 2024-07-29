using XOSimpleToolkit.ClassicXO.Game;
using XOSimpleToolkit.Common.Enums;

namespace XOSimpleToolkit.Tests
{
    public class SessionTests
    {
        [Test]
        public void ClassicXOSession_CantSelectCellTwice()
        {
            var session = new ClassicXOSession();
            var secondMoveMade = false;
            session.Start(Difficulty.Normal, Turn.Human);

            session.Move(0, 0);
            session.HumanMoveEvent += move => secondMoveMade = true;
            session.Move(0, 0);

            Assert.That(secondMoveMade, Is.False, "Был дважды сделан ход по одной клетке");
        }
    }
}
