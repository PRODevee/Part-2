using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public class GameEngine
    {
        private Map map;

        private Form1 form = new Form1();

        private Hero hero = new Hero(9, 8, 10);

        private Enemy enemy;

        private Character character;
        //getter and accessors for map

        public string Display
        {
            get { return map.ToString(); }
        }
        //constructors of GameEngine
        public GameEngine()
        {
            map = new Map(10, 20, 15, 25, 4);
        }

        public bool MovePlayer(Movement direction)
        {//The characters movements accros the map
            if (direction == Movement.No_movement)
            {
                return false;
            }

            Movement validMove = map.Hero.ReturnMove(direction);
            if (validMove == Movement.No_movement)
            {
                return false;
            }

            map.Hero.Move(validMove);
            map.UpdateMap();
            map.UpdateVision();

            return true;
        }

        public string Herostats()
        {//Displays Hero's stats
            return "Hero :" + hero.Hp + "/" + hero.MaxHp + " HP";
        }

        public string PlayerAttack(Movement direction)
        {
            if (direction == Movement.No_movement)
            {
                return "Attack Failed";
            }

            Tile tile = map.Hero.Vision[(int)direction];

            if (tile is Enemy)
            {
                map.Hero.Attack((Enemy)tile);
                return "Hero attacked: " + enemy.ToString();
            }

            return "Attack failed, no enemy in this direction";
        }
    }
}
