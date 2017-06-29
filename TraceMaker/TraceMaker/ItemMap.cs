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
        private Item[] _map;
        private Point _size;
        //todo map array list; 

        public ItemMap(Texture2D[] textures, Texture2D bitMap, int capacity)
        {
            _map = new Item[capacity];
            _size = new Point(textures[0].Width, textures[0].Height);
            BuildMap(textures, bitMap);
        }

        public Point GetSize()
        {
            return _size;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _map.Length; y++)// for each loop
            {
                _map[y].Draw(spriteBatch);
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

            for (int y = 0; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    if (colores[y * _map.GetLength(0) + x] == Color.White)
                    {   //White
                        _map[idCounter] = new Item(textures[0], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Black)
                    {   //Black
                        _map[idCounter] = new Item(textures[1], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Brown)
                    {   //Brown
                        _map[idCounter] = new Item(textures[2], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Blue)
                    {   //Blue
                        _map[idCounter] = new Item(textures[3], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Gray)
                    {   //Gray
                        _map[idCounter] = new Item(textures[4], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Green)
                    {   //Green
                        _map[idCounter] = new Item(textures[5], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Orange)
                    {   //Orange
                        _map[idCounter] = new Item(textures[6], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Pink)
                    {   //Pink
                        _map[idCounter] = new Item(textures[7], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Yellow)
                    {   //Yellow
                        _map[idCounter] = new Item(textures[8], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }
                    else
                    {   //Red
                        _map[idCounter] = new Item(textures[textures.Length - 1], new Vector2(x * _size.X, y * _size.Y), idCounter);
                        idCounter++;
                    }

                }
            }
        }
    }
}
