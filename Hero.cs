using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public class Hero : Character
    {
        Obstacle obstacle = new Obstacle(6, 12);
        public Hero(int x, int y, int hp) : base(x, y)
        {
            maxHp = hp;
            hp = this.hp;
            this.damage = 2;
        }

        public override string ToString()
        {
            return "Player stats:\n" +
                    "Hp: " + hp + "/" + maxHp + "\n" +
                    "Damage: " + damage +
                    "[" + x + "," + y + "]";
        }
        public override Movement ReturnMove(Movement move = 0)
        {

            //Keys key = Keys.W;
            if (move == Movement.No_movement)
            {
                return move;
            }
            //late Change to walk on to gold or Weapon tiles 
            //for now Herocan only move on to an Empty tile
            if (!(vision[(int)move] is EmptyTile))
            {
                return move;
            }

            return Movement.No_movement;
        }
    }
}
