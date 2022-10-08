using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public abstract class Enemy : Character
    {
        protected Random ran;
        //Constructor for Enemy.cs inherits from Character
        public Enemy(int x, int y, int damage, int hp, int maxHp) : base(x, y)//symbol
        {
            this.damage = damage;
            this.hp = hp;
            this.maxHp = maxHp;
            ran = new Random();
        }
        //The ToString overrided from Character.cs
        public override string ToString()
        {
            return GetType() + " at [" + x.ToString() + "," + y.ToString() + "] (" + damage.ToString() + ")";
            //return $"{GetType())} at [{x}, {y}] [{damage} DMG)";
        }
    }
}
