using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public enum Movement
    {
        Up,
        Right,
        Down,
        Left,
        No_movement
    }
    public abstract class Character : Tile
    {

        protected int hp;
        protected int maxHp;
        protected int damage;
        protected int goldPurse = 0;
        //Vision array
        protected Tile[] vision = new Tile[4];

        //getter and accessors
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public Tile[] Vision
        {
            get { return vision; }
        }

        public int MaxHp
        {
            get { return maxHp; }
            set { maxHp = value; }
        }

        public int Damage
        {
            get { return Damage; }
            set { damage = value; }
        }

        public int GoldPurse
        {
            get { return goldPurse; }
            set { goldPurse = value; }
        }

        public Movement movement
        {
            get; set;
        }
        //Constructor for Character.cs and inherits from Tile.cs
        public Character(int x, int y) : base(x, y)
        {

        }
        //Attack method that allows characters to attack each other
        public virtual void Attack(Character target)
        {
            target.hp -= damage;
            if (target.hp < 0)
            {
                target.hp = 0;
            }
        }

        public void Pickup(Item i)
        {
            if (this.x == i.X && this.y == i.Y)
            {
                goldPurse += 1;
            }
        }

        //Checks if character is dead
        public bool IsDead
        {
            get { return hp <= 0; }
        }

        //Checks distance between characters
        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Calculates distance between characters
        private int DistanceTo(Character target)
        {
            int distancex = Math.Abs(target.X - x);
            int distancey = Math.Abs(target.Y - y);

            return distancex + distancey;
        }
        //Movement for characters;
        public void Move(Movement move)
        {
            move = Movement.No_movement;
            if (move == Movement.No_movement)
                return;

            switch (move)
            {
                case Movement.Up:
                    y--;
                    break;
                case Movement.Down:
                    y++;
                    break;
                case Movement.Right:
                    x++;
                    break;
                case Movement.Left:
                    x--;
                    break;
                case Movement.No_movement:
                    x = x;
                    y = y;
                    break;
            }
        }
        //abstract classes
        public abstract Movement ReturnMove(Movement move = Movement.No_movement);

        public abstract override string ToString();
    }
}
