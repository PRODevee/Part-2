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
        private string[,] stringMap;
        private Hero hero;
        private Enemy[] enemy;

        private int width;
        private int height;

        private Random ran;

        private int enemies;
        private int items;
        private Item[] item;
        private Gold gold;

        private Tile tile;
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
        public Map(int minWidth, int maxWidth, int minHeight, 
            int maxHeight, int enemies, int items) 
        { 
            width = ran.Next(minWidth, maxWidth);
            height = ran.Next(minHeight, maxHeight);

            map = new Tile[width, height];
            IntialiseMap();

            enemy = new Enemy[enemies];
            item = new Item[items];

            this.items = items;
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
                        stringMap[x, y] = "*";
                        s = stringMap[x, y];
                    }
                    else if (tile is Obstacle)
                    {
                        stringMap[x, y] = "X";
                        s = stringMap[x, y];
                    }
                    else if (tile is Enemy)
                    {
                        Enemy enemy = (Enemy)tile;
                        if (enemy.IsDead)
                        {
                            stringMap[x, y] = "/";
                            s = stringMap[x, y];
                        }
                        else
                        {
                            if (enemy is SwampCreature)
                            {
                                stringMap[x, y] = "S";
                                s = stringMap[x, y];
                            }
                            else if (enemy is Mage)
                            {                     
                                stringMap[x, y] = "M";
                                s = stringMap[x, y];
                            }
                        }
                    }
                    else if (tile is Hero)
                    {                       
                        stringMap[x, y] = "H";
                        s = stringMap[x, y];
                    }
                    else if (tile is Item)
                    {
                        if (item is Gold)
                        {                          
                            stringMap[x, y] = "G";
                            s = stringMap[x, y];
                        }
                    }
                }
            }
            return s;
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
                int enemyType = ran.Next(0, 1);
                if (enemyType == 0)
                {
                    map[tileX, tileY] = new SwampCreature(tileX, tileY);
                }
                else if(enemyType == 1)
                {
                    map[tileX, tileY] = new Mage(tileX, tileY); 
                }
            } 
            else if (objtype == TileType.Gold)
            {
                for (int i = 0; i <= gold.AmntOfGold; i++)
                {
                    map[tileX, tileY] = new Gold(tileX, tileY);
                }
 
            }

            return map[tileX, tileY];
        }

        public void PickupItem()
        {

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (stringMap[x, y] == "G")
                    {
                        stringMap[x, y] = "H";
                    }
                }
            }
        }

        public Item GetItemAtPosition(int x, int y)
        {
            for (int i = 0; i <= items; i++)
            {
                if(gold.X == x && gold.Y == y)
                {
                    return gold;
                    // item[items] == Item[]; how to make null in array
                }
            }
            return null;
        }
    }
}
