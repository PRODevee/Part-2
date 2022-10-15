using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public class Mage :Enemy
    {
        public Mage(int x, int y) : base(x, y, 5, 5, 5)
        {

        }

        public override Movement ReturnMove(Movement move = 0)
        {
            return Movement.No_movement;
        }

        public override bool CheckRange(Character target)
        {
            
            int distancex = Math.Abs(target.X - x);
            int distancey = Math.Abs(target.Y - y);
            int totdistance = distancex + distancey;
            if (totdistance == -2 || totdistance == 2 || totdistance == -1 || totdistance == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
    }
}
