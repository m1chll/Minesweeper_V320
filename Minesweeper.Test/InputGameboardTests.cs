using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Minesweeper.Test
{
    [TestClass]
    public class InputGameboardTests
    {
        [TestMethod]
        public void TestRevealField()
        {
            // Arrange
            var gameboard = new Gameboard();
            gameboard.CreateFields(8, 8);
            gameboard.Fields[0][0].IsBomb = false;

            // Act
            var status = gameboard.UpdateFields(new FieldInput(0, 0, FieldInput.UserAction.Reveal));

            // Assert
            if (status == GameStatus.Lost)
            {
                Console.WriteLine("Game Lost");
            }
            else
            {
                Console.WriteLine("Game Ongoing");
            }
        }

        [TestMethod]
        public void TestPlaceFlag()
        {
            // Arrange
            var gameboard = new Gameboard();
            gameboard.CreateFields(8, 8);

            // Act
            gameboard.UpdateFields(new FieldInput(0, 0, FieldInput.UserAction.Flag));

            // Assert
            if (gameboard.Fields[0][0].HasFlag)
            {
                Console.WriteLine("Flag placed successfully");
            }
            else
            {
                Console.WriteLine("Failed to place flag");
            }
        }

        [TestMethod]
        public void TestRemoveFlag()
        {
            // Arrange
            var gameboard = new Gameboard();
            gameboard.CreateFields(8, 8);
            gameboard.Fields[0][0].HasFlag = true;

            // Act
            gameboard.UpdateFields(new FieldInput(0, 0, FieldInput.UserAction.RemoveFlag));

            // Assert
            if (!gameboard.Fields[0][0].HasFlag)
            {
                Console.WriteLine("Flag removed successfully");
            }
            else
            {
                Console.WriteLine("Failed to remove flag");
            }
        }

    }
}
