using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public class SwampCreature : Enemy
    {
        Hero hero;
        //Constructor for SwampCreature and inherits from Enemy
        public SwampCreature(int x, int y) : base(x, y, 1, 10, 10)
        {

        }

        //Movement of Enemy
        public override Movement ReturnMove(Movement move = 0)
        {
            int ran_num = ran.Next(4);

            List<int> checkedDirections = new List<int>();
            while (checkedDirections.Count < 4 && vision[ran_num] is not EmptyTile)
            {
                checkedDirections.Add(ran_num);
                ran_num = ran.Next(4);
            }

            if (checkedDirections.Count == 4)
                return Movement.No_movement;

            return (Movement)ran_num;

        }
    }
}
