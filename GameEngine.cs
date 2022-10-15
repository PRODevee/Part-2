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

        private Random ran;

        private Hero hero = new Hero(9, 8, 10);

        private Enemy enemy;
        //getter and accessors for map

        public string Display
        {
            get { return map.ToString(); }
        }
        //constructors of GameEngine
        public GameEngine()
        {
            map = new Map(10, 20, 15, 25, 4, 5);
        }

        public bool MovePlayer(Movement direction)
        {//The characters movements across the map
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

            if (hero is Gold)
            {
                map.PickupItem();
            }

            return true;
        }

        public string Herostats()
        {//Displays Hero's stats
            return "Hero :" + hero.Hp + "/" + hero.MaxHp + "HP" +
                " \n Gold Purse: " + hero.GoldPurse;
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

        public void EnemyAttacks()
        {
            Movement directionAttack = MoveEnemies();
            for (int i = 0; i < map.Enemies; i++)
            {
                
            }
        }

        public Movement MoveEnemies()
        {
            int ran_num = ran.Next(4);
            Movement validMove = enemy.ReturnMove((Movement)ran_num);

            for (int i = 0; i < map.Enemies; i++)
            {
                if (validMove == Movement.No_movement)
                {
                    enemy.Move(validMove);
                    map.UpdateMap();
                    map.UpdateVision();
                    return Movement.No_movement;
                }
                else if (validMove == Movement.Up)
                {
                    enemy.Move(validMove);
                    map.UpdateMap();
                    map.UpdateVision();
                    return Movement.Up;
                }
                else if (validMove == Movement.Left)
                {
                    enemy.Move(validMove);
                    map.UpdateMap();
                    map.UpdateVision();
                    return Movement.Left;
                }
                else if (validMove == Movement.Right)
                {
                    enemy.Move(validMove);
                    map.UpdateMap();
                    map.UpdateVision();
                    return Movement.Right;
                }
                else
                {
                    enemy.Move(validMove);
                    map.UpdateMap();
                    map.UpdateVision();
                    return Movement.Down;
                }
            }


            return Movement.No_movement;
        }
    }
}
