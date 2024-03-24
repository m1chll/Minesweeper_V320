using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper;

public class GameboardMemento
{
    public List<List<Field>> State { get; private set; }

    public GameboardMemento(List<List<Field>> state)
    {
        // Erstelle eine tiefe Kopie des Zustandes, um sicherzustellen, dass Referenzen nicht das Original beeinflussen
        State = state.Select(row => row.Select(field => field.Clone()).ToList()).ToList();
    }
}
