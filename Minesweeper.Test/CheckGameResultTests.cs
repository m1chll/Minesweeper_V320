using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Test
{
    [TestClass]
    public class CheckGameResulttests
    {
        [TestMethod]
        public void RevealingBombEndsGame()
        {
            // Arrange
            Game game = new Game();
            Gameboard gameboard = new Gameboard();
            FieldInput bombFieldInput = new FieldInput(0, 0, FieldInput.UserAction.Reveal);
            gameboard.CreateFields(3, 3);
            gameboard.Fields[0][0].IsBomb = true;

            // Act
            GameStatus status = gameboard.UpdateFields(bombFieldInput);

            // Assert
            Assert.AreEqual(GameStatus.Lost, status);
        }

        [TestMethod]
        public void RevealingAllNonBombFieldsWinsGame()
        {
            // Arrange
            Game game = new Game();
            Gameboard gameboard = new Gameboard();
            gameboard.CreateFields(3, 3);
            gameboard.Fields[0][0].IsBomb = false;
            gameboard.Fields[0][1].IsBomb = false;
            gameboard.Fields[0][2].IsBomb = false;
            gameboard.Fields[1][0].IsBomb = false;
            gameboard.Fields[1][1].IsBomb = false;
            gameboard.Fields[1][2].IsBomb = false;
            gameboard.Fields[2][0].IsBomb = false;
            gameboard.Fields[2][1].IsBomb = false;
            gameboard.Fields[2][2].IsBomb = false;

            // Act
            // Assuming the player reveals all non-bomb fields here...
            gameboard.UpdateFields(new FieldInput(0, 0, FieldInput.UserAction.Reveal));
            gameboard.UpdateFields(new FieldInput(0, 1, FieldInput.UserAction.Reveal));
            gameboard.UpdateFields(new FieldInput(0, 2, FieldInput.UserAction.Reveal));
            gameboard.UpdateFields(new FieldInput(1, 0, FieldInput.UserAction.Reveal));
            gameboard.UpdateFields(new FieldInput(1, 1, FieldInput.UserAction.Reveal));
            gameboard.UpdateFields(new FieldInput(1, 2, FieldInput.UserAction.Reveal));
            gameboard.UpdateFields(new FieldInput(2, 0, FieldInput.UserAction.Reveal));
            gameboard.UpdateFields(new FieldInput(2, 1, FieldInput.UserAction.Reveal));
            gameboard.UpdateFields(new FieldInput(2, 2, FieldInput.UserAction.Reveal));

            // Assert
            Assert.AreEqual(GameStatus.Won, game.GameStatus);
        }
    }
}
