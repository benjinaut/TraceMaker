using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TraceMaker
{
    class TileMap : Maps
    {
        private Tile[,] map;
        private Point size;
        private Vector2 startpoint;

        public TileMap(Texture2D[] textures, Texture2D bitMap)
        {
            map =new Tile[bitMap.Width,bitMap.Height];
            size = new Point(textures[0].Width, textures[0].Height);
            BuildMap(textures,bitMap);
        }

        public Point GetSize()
        {
            return size;
        }

        public Vector2 GetStartPoint()
        {
            return startpoint;
        }

        public bool Walkable(Vector2 currentPosition)
        {
            return map[(int)(currentPosition.X / size.X), (int)(currentPosition.Y / size.Y)].Walkable();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    map[x, y].Draw(spriteBatch);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        protected override void BuildMap(Texture2D[] textures, Texture2D bitMap)
        {
            Color[] colores = new Color[bitMap.Width * bitMap.Height];
            bitMap.GetData(colores);

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (colores[y * map.GetLength(0) + x] == Color.White)
                    {   //White
                        map[x, y] = new Tile(textures[0], new Vector2(x * size.X, y * size.Y), 0);
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Black)
                    {   //Black
                        map[x, y] = new Tile(textures[1], new Vector2(x * size.X, y * size.Y), 1);
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Brown)
                    {   //Brown
                        map[x, y] = new Tile(textures[2], new Vector2(x * size.X, y * size.Y), 2);
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Blue)
                    {   //Blue Startpoint 
                        map[x, y] = new Tile(textures[3], new Vector2(x * size.X, y * size.Y), 0);
                        startpoint = new Vector2(x * size.X, y * size.Y);
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Gray)
                    {   //Gray
                        map[x, y] = new Tile(textures[4], new Vector2(x * size.X, y * size.Y), 4);
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Green)
                    {   //Green
                        map[x, y] = new Tile(textures[5], new Vector2(x * size.X, y * size.Y), 5);
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Orange)
                    {   //Orange
                        map[x, y] = new Tile(textures[6], new Vector2(x * size.X, y * size.Y), 6);
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Pink)
                    {   //Pink
                        map[x, y] = new Tile(textures[7], new Vector2(x * size.X, y * size.Y), 7);
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Yellow)
                    {   //Yellow
                        map[x, y] = new Tile(textures[8], new Vector2(x * size.X, y * size.Y), 8);
                    }
                    else
                    {   //Red
                        map[x, y] = new Tile(textures[textures.Length-1], new Vector2(x * size.X, y * size.Y), textures.Length - 1);
                    }

                }
            }
        }
    }
}
