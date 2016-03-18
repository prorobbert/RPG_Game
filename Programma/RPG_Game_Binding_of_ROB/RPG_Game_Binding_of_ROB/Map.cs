using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Binding_of_ROB
{
    public class Map
    {
        private Sprite[,] tilebox;
        private int mapheight;
        private int mapwidth;

        public Map(Int32 tilemapwidth,Int32 tilemapheight)
        {
            Texture texture = new Texture("C:/Users/barry.BarrydeKoning/OneDrive/Huiswerk Barry de Koning/RPG_Game/Sprites/Terrain/CastleExample.png");
            Sprite[] tilemap = new Sprite[tilemapwidth * tilemapheight];
            Int16 tileSize = 32;
            Int16 tilesize = 32;

            for (int y = 0; y < tilemapheight; y++)
            {
                for (int x = 0; x < tilemapwidth; x++)
                {
                    IntRect rect = new IntRect(x * tileSize, y * tileSize, tilesize, tilesize);
                    tilemap[(y * tilemapwidth) + x] = new Sprite(texture, rect);
                }
            }

            Sprite[,] tiles = new Sprite[tileSize, tilesize];
            StreamReader streamReader = new StreamReader(@"Maps/TestMap_Test.csv");

            for (int y = 0; y < tilesize; y++)
            {
                string line = streamReader.ReadLine();
                string[] items = line.Split(',');

                for (int x = 0; x < tileSize; x++)
                {
                    int id = Convert.ToInt32(items[x]);
                    tiles[x, y] = new Sprite(tilemap[id]);
                    tiles[x, y].Position = new SFML.System.Vector2f(tileSize * x, tileSize * y);
                }
            }
            Tilebox = tiles;
            streamReader.Close();



        }

        public Sprite[,] Tilebox
        {
            get { return tilebox; }
            set { tilebox = value; }
        }

        public int mapHeight
        {
            get { return mapheight; }
            set { mapheight = value; }
        }

        public int mapWidth
        {
            get { return mapwidth; }
            set { mapwidth = value; }
        }

        public void Draw(RenderWindow window)
        {
            Sprite[,] Drawmap = Tilebox;
            int tilemapheight = mapHeight;
            int tilemapwidth = mapWidth;

            for (int y = 0; y < tilemapheight; y++)
            {
                for (int x = 0; x < tilemapwidth; x++)
                {
                    window.Draw(Drawmap[x, y]);
                }
            }

        }
    }
} 
