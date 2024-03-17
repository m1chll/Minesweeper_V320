using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper;

public interface IStrategy
{
    int XSize { get; }
    int xSize { get; }
    int YSize { get; }
    int ySize { get; }
    int NumberOfBombs { get; }
    int numberOfBombs { get; }
}
