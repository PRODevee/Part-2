using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public abstract class Item : Tile
    {
        public Item(int x, int y) : base(x, y)
        {

        }

        public abstract override string ToString();
    }
}
