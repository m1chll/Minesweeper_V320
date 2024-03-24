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
                Console.SetOut(sw);
                Console.SetIn(new StringReader("E\n"));

                var expectedDifficulty = "E";
                var actualDifficulty = GetDifficulty();

                Assert.AreEqual(expectedDifficulty, actualDifficulty);
            }
        }

        
        [TestMethod]
        public void GetDifficulty_MediumInput_ReturnsMedium()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("M\n"));

                var expectedDifficulty = "M";
                var actualDifficulty = GetDifficulty();

                Assert.AreEqual(expectedDifficulty, actualDifficulty);
            }
        }

        
        [TestMethod]
        public void GetDifficulty_HardInput_ReturnsHard()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("H\n"));

                var expectedDifficulty = "H";
                var actualDifficulty = GetDifficulty();

                Assert.AreEqual(expectedDifficulty, actualDifficulty);
            }
        }

        // Method to invoke the method being tested
        private string GetDifficulty()
        {
            Console.WriteLine("Please enter your difficulty: ");
            Console.WriteLine("E = Easy");
            Console.WriteLine("M = Medium");
            Console.WriteLine("H = Hard");

            // Read input from the console and convert it to uppercase
            string difficulty = Console.ReadLine().ToUpper();

            return difficulty;
        }

    }
}
