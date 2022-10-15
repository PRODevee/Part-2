using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public class Gold : Item
    {
        private int amntOfGold;
        private Random ranGold;

        public int AmntOfGold
        {
            get { return amntOfGold; } 
        }

        public Gold(int x, int y) : base(x, y)
        {
            ranGold = new Random();
            amntOfGold = ranGold.Next(0, 5);
        }
    }
}
