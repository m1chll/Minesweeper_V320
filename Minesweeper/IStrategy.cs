using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper;

public interface IStrategy
{
    int XSize { get; }
    int YSize { get; }

    int NumberOfBombs { get; }
}
