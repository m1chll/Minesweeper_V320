using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper;

public class Field
{
    internal bool isBomb;
    internal int bombsAround;

    public bool IsBomb { get; set; } = false;
    public bool HasFlag { get; set; } = false;
    public bool IsVisible { get; set; } = false;
    public int BombsAround { get; set; }        
}
