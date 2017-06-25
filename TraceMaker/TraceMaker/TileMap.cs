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
        private Tile[,] _map;
        private Point _size;

        public TileMap(Texture2D[] textures, Texture2D bitMap)
        {
            _map =new Tile[bitMap.Width,bitMap.Height];
            _size = new Point(textures[0].Width, textures[0].Height);
            BuildMap(textures,bitMap);
        }

        public Point GetSize()
        {
            return _size;
        }

        public bool Walkable(Vector2 currentPosition)
        {
            return _map[(int)(currentPosition.X / _size.X), (int)(currentPosition.Y / _size.Y)].Walkable();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    _map[x, y].Draw(spriteBatch);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        protected override void BuildMap(Texture2D[] textures, Texture2D bitMap)
        {
            Color[] colores = new Color[bitMap.Width * bitMap.Height];
            bitMap.GetData(colores);

            for (int y = 0; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    if (colores[y * _map.GetLength(0) + x] == Color.White)
                    {
                        _map[x, y] = new Tile(textures[0], new Vector2(x * _size.X, y * _size.Y), 0);
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Brown)
                    {
                        _map[x, y] = new Tile(textures[1], new Vector2(x * _size.X, y * _size.Y), 1);
                    }
                    else if (colores[y * _map.GetLength(0) + x] == Color.Blue)
                    {
                        _map[x, y] = new Tile(textures[2], new Vector2(x * _size.X, y * _size.Y), 2);
                    }
                    else
                    {
                        _map[x, y] = new Tile(textures[3], new Vector2(x * _size.X, y * _size.Y), 3);
                    }

                }
            }
        }
    }
}
