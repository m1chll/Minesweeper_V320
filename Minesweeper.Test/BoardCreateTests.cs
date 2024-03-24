using System.Xml.Schema;

namespace Minesweeper.Test
{
    [TestClass]
    public class BoardCreateTests
    {
        [TestMethod]
        public void CreateGameboard_EasyLevel_CreatesCorrectSizeAndBombs()
        {
            // Arrange
            GameboardCreator gameboardCreator = new GameboardCreator();

            // Act
            Gameboard gameboard = gameboardCreator.CreateGameboard("E");

            // Assert
            Assert.AreEqual(8, gameboard.XSize);
            Assert.AreEqual(8, gameboard.YSize);
            Assert.AreEqual(10, gameboard.BombCount);
        }

        [TestMethod]
        public void CreateGameboard_MediumLevel_CreatesCorrectSizeAndBombs()
        {
            // Arrange
            GameboardCreator gameboardCreator = new GameboardCreator();

            // Act
            Gameboard gameboard = gameboardCreator.CreateGameboard("M");

            // Assert
            Assert.AreEqual(16, gameboard.XSize);
            Assert.AreEqual(16, gameboard.YSize);
            Assert.AreEqual(40, gameboard.BombCount);
        }

        [TestMethod]
        public void CreateGameboard_HardLevel_CreatesCorrectSizeAndBombs()
        {
            // Arrange
            GameboardCreator gameboardCreator = new GameboardCreator();

            // Act
            Gameboard gameboard = gameboardCreator.CreateGameboard("H");

            // Assert
            Assert.AreEqual(30, gameboard.XSize);
            Assert.AreEqual(16, gameboard.YSize);
            Assert.AreEqual(99, gameboard.BombCount);
        }
    }
}