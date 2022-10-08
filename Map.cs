using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0
{
    public class Map
    {
        private Tile[,] map;
        private Hero hero;
        private Enemy[] enemy;
        private int width;
        private int height;
        private Random ran;
        private int enemies;


        private Tile tile;
        private SwampCreature sCreature;

        private GameEngine gameEngine;

        private Character character;
        //Getter and Accesssors of Map
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Tile[,] MapA
        {
            get { return map; }
            set { map = value; }
        }

        public int Enemies
        {
            get { return enemies; }
        }

        public Hero Hero { get { return hero; } }

        //Map Constructor
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemies)
        {
            ran = new Random();

            width = ran.Next(minWidth, maxWidth);
            height = ran.Next(minHeight, maxHeight);

            map = new Tile[width, height];
            IntialiseMap();

            enemy = new Enemy[enemies];

            this.enemies = enemies;

            hero = (Hero)Create(TileType.Hero);
            for (int i = 0; i < enemies; i++)
            {
                enemy[i] = (Enemy)Create(TileType.Enemy);
            }

            UpdateVision();
            //MapCreate();

        }
        public void UpdateVision()
        {

            hero.UpdateVision(map);
            foreach (Enemy enemy in enemy)
            {
                enemy.UpdateVision(map);
            }
        }

        public void UpdateMap()
        {
            IntialiseMap();

            foreach (Enemy enemy in enemy)
            {
                map[enemy.X, enemy.Y] = enemy;
            }
            //Place hero last, so it is not overwritten by any other tiles            
            map[hero.X, hero.Y] = hero;

        }

        private void IntialiseMap()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        map[x, y] = new Obstacle(x, y);
                    }
                    else
                    {
                        map[x, y] = new EmptyTile(x, y);
                    }
                }
            }
        }

        public override string ToString()
        {
            string s = "";

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tile is EmptyTile)
                    {
                        s = "*";
                    }
                    else if (tile is Obstacle)
                    {
                        s = "X";
                    }
                    else if (tile is Enemy)
                    {
                        Enemy enemy = (Enemy)tile;
                        if (enemy.IsDead)
                        {
                            s += "/";
                        }
                        else
                        {
                            if (enemy is SwampCreature)
                            {
                                s += "S";
                            }
                        }
                    }
                    else if (tile is Hero)
                    {
                        s += "H";
                    }
                }
            }
            return "";
        }
        private Tile Create(TileType objtype)
        {//Creates the characters coordinates 

            int tileX = ran.Next(1, width - 1);
            int tileY = ran.Next(1, height - 1);

            while (!(map[tileX, tileY] is EmptyTile))
            {
                tileX = ran.Next(1, width - 1);
                tileY = ran.Next(1, height - 1);
            }

            if (objtype == TileType.Hero)
            {
                map[tileX, tileY] = new Hero(tileX, tileY, 10);
            }
            else if (objtype == TileType.Enemy)
            {
                int enemyType = ran.Next(0);
                if (enemyType == 0)
                {
                    map[tileX, tileY] = new SwampCreature(tileX, tileY);
                }
            }

            return map[tileX, tileY];
        }
    }
}
