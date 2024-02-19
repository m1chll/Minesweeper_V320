using System.Xml.Schema;

namespace Minesweeper.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var model = new Model(100);
            model.DoTurn("C2");

            // ASSERT
            // -> Prüfung Spielzustand
        }
    }
}