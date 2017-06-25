using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TraceMaker
{
    class Collider
    {
        private Point _size;

        public Collider(Point size)
        {
            _size = size;
        }

        public bool ColObj()
        {
            return true;
        }


        public bool ColHor(float moveX, Vector2 position)
        {
            if (moveX < 0) //left
            {
                for (int i = 0; i * GS.I._tileMap.GetSize().Y < _size.Y; i++)
                {
                    if (!GS.I._tileMap.Walkable(new Vector2(position.X + moveX, position.Y + i * GS.I._tileMap.GetSize().Y)))
                    {
                        return true;
                    }
                }
                return !GS.I._tileMap.Walkable(new Vector2(position.X + moveX, position.Y + _size.Y));
            }
            if (moveX > 0) //right
            {
                for (int i = 0; i * GS.I._tileMap.GetSize().Y < _size.Y; i++)
                {
                    if (!GS.I._tileMap.Walkable(new Vector2(position.X + moveX + _size.X, position.Y + i * GS.I._tileMap.GetSize().Y)))
                    {
                        return true;
                    }
                }
                return !GS.I._tileMap.Walkable(new Vector2(position.X + moveX + _size.X, position.Y + _size.Y));
            }
            return false; //nope nope nope
        }

        public bool ColVer(float moveY, Vector2 position)
        {
            if (moveY < 0) //up
            {
                for (int i = 0; i * GS.I._tileMap.GetSize().X < _size.X; i++)
                {
                    if (!GS.I._tileMap.Walkable(new Vector2(position.X + i * GS.I._tileMap.GetSize().X, position.Y + moveY)))
                    {
                        return true;
                    }
                }
                return !GS.I._tileMap.Walkable(new Vector2(position.X + _size.X, position.Y + moveY));
            }
            if (moveY > 0) //down
            {
                for (int i = 0; i * GS.I._tileMap.GetSize().X < _size.X; i++)
                {
                    if (!GS.I._tileMap.Walkable(new Vector2(position.X + i * GS.I._tileMap.GetSize().X, position.Y + moveY + _size.Y )))
                    {
                        return true;
                    }
                }
                return !GS.I._tileMap.Walkable(new Vector2(position.X + _size.X, position.Y + moveY + _size.Y));
            }
            return false; //nope nope nope
        }
    }
}
