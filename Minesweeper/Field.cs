using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper;

public class Field
{
    public bool IsBomb { get; set; }    
    public bool HasFlag { get; set; }   
    public bool IsVisible { get; set; }
    public int BombsAround { get; set; }

    public string GetType()
    {
        string type;
        if (IsVisible)

        return type;
    }
        
}
