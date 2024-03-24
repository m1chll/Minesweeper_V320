using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Test
{
    [TestClass]
    public class DifficultyTests
    {
        
        [TestMethod]
        public void GetDifficulty_EasyInput_ReturnsEasy()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Arrange
                Console.SetOut(sw);
                Console.SetIn(new StringReader("E\n"));

                // Act
                var expectedDifficulty = "E";
                var actualDifficulty = GetDifficulty();

                // Assert
                Assert.AreEqual(expectedDifficulty, actualDifficulty);
            }
        }

        
        [TestMethod]
        public void GetDifficulty_MediumInput_ReturnsMedium()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Arrange
                Console.SetOut(sw);
                Console.SetIn(new StringReader("M\n"));

                // Act
                var expectedDifficulty = "M";
                var actualDifficulty = GetDifficulty();

                // Assert
                Assert.AreEqual(expectedDifficulty, actualDifficulty);
            }
        }

        
        [TestMethod]
        public void GetDifficulty_HardInput_ReturnsHard()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Arrange
                Console.SetOut(sw);
                Console.SetIn(new StringReader("H\n"));

                // Act
                var expectedDifficulty = "H";
                var actualDifficulty = GetDifficulty();

                // Assert
                Assert.AreEqual(expectedDifficulty, actualDifficulty);
            }
        }

        [TestMethod]
        public void GetDifficulty_InvalidInput_NothingHappens()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Arrange
                Console.SetOut(sw);
                Console.SetIn(new StringReader("X\n"));

                // Act
                GetDifficulty();

                // Asserts
                Assert.AreEqual("Please enter your difficulty: \r\nE = Easy\r\nM = Medium\r\nH = Hard\r\n", sw.ToString());
            }

        }

            private string GetDifficulty()
        {
            Console.WriteLine("Please enter your difficulty: ");
            Console.WriteLine("E = Easy");
            Console.WriteLine("M = Medium");
            Console.WriteLine("H = Hard");

            string difficulty = Console.ReadLine().ToUpper();

            return difficulty;
        }

      

    }
}
