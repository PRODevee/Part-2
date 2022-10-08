using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public enum TileType
    {
        Hero,
        Enemy,
        Gold,
        Weapon,
        Obstacle,
        None
    }
    public abstract class Tile
    {
        protected int x;
        protected int y;
        protected TileType type;

        //getter and accessor for x and y integers
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        //Constructor of Tile.cs
        public Tile(int x, int y)//tiletype still pending how to use
        {
            this.x = x;
            this.y = y;
            this.type = TileType.None;
        }

    }
}
