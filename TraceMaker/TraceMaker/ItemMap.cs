using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TraceMaker
{
    class ItemMap : Maps
    {
        private Item[] map;
        private Point size;
        //todo map array list; 

        public ItemMap(Texture2D[] textures, Texture2D bitMap, int capacity)
        {
            map = new Item[capacity];
            size = new Point(textures[0].Width, textures[0].Height);
            BuildMap(textures, bitMap);
        }

        public Point GetSize()
        {
            return size;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < map.Length; y++)// for each loop
            {
                map[y].Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {

        }

        protected override void BuildMap(Texture2D[] textures, Texture2D bitMap)
        {
            Color[] colores = new Color[bitMap.Width * bitMap.Height];
            bitMap.GetData(colores);
            int idCounter = 0;

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (colores[y * map.GetLength(0) + x] == Color.White)
                    {   //White
                        map[idCounter] = new Item(textures[0], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Black)
                    {   //Black
                        map[idCounter] = new Item(textures[1], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Brown)
                    {   //Brown
                        map[idCounter] = new Item(textures[2], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Blue)
                    {   //Blue
                        map[idCounter] = new Item(textures[3], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Gray)
                    {   //Gray
                        map[idCounter] = new Item(textures[4], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Green)
                    {   //Green
                        map[idCounter] = new Item(textures[5], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Orange)
                    {   //Orange
                        map[idCounter] = new Item(textures[6], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Pink)
                    {   //Pink
                        map[idCounter] = new Item(textures[7], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * map.GetLength(0) + x] == Color.Yellow)
                    {   //Yellow
                        map[idCounter] = new Item(textures[8], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }
                    else
                    {   //Red
                        map[idCounter] = new Item(textures[textures.Length - 1], new Vector2(x * size.X, y * size.Y), idCounter);
                        idCounter++;
                    }

                }
            }
        }
    }
}
