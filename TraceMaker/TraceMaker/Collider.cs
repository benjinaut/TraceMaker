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
        private Point size;

        public Collider(Point _size)
        {
            size = _size;
        }

        public bool ColObj()
        {
            return true;
        }


        public bool Horizontal(float moveX, Vector2 position)
        {
            if (moveX < 0) //left
            {
                for (int i = 0; i * GS.I.tileMap.GetSize().Y < size.Y; i++)
                {
                    if (!GS.I.tileMap.Walkable(new Vector2(position.X + moveX, position.Y + i * GS.I.tileMap.GetSize().Y)))
                    {
                        return true;
                    }
                }
                return !GS.I.tileMap.Walkable(new Vector2(position.X + moveX, position.Y + size.Y));
            }
            if (moveX > 0) //right
            {
                for (int i = 0; i * GS.I.tileMap.GetSize().Y < size.Y; i++)
                {
                    if (!GS.I.tileMap.Walkable(new Vector2(position.X + moveX + size.X, position.Y + i * GS.I.tileMap.GetSize().Y)))
                    {
                        return true;
                    }
                }
                return !GS.I.tileMap.Walkable(new Vector2(position.X + moveX + size.X, position.Y + size.Y));
            }
            return false; //nope nope nope
        }

        public bool Vertical(float moveY, Vector2 position)
        {
            if (moveY < 0) //up
            {
                for (int i = 0; i * GS.I.tileMap.GetSize().X < size.X; i++)
                {
                    if (!GS.I.tileMap.Walkable(new Vector2(position.X + i * GS.I.tileMap.GetSize().X, position.Y + moveY)))
                    {
                        return true;
                    }
                }
                return !GS.I.tileMap.Walkable(new Vector2(position.X + size.X, position.Y + moveY));
            }
            if (moveY > 0) //down
            {
                for (int i = 0; i * GS.I.tileMap.GetSize().X < size.X; i++)
                {
                    if (!GS.I.tileMap.Walkable(new Vector2(position.X + i * GS.I.tileMap.GetSize().X, position.Y + moveY + size.Y )))
                    {
                        return true;
                    }
                }
                return !GS.I.tileMap.Walkable(new Vector2(position.X + size.X, position.Y + moveY + size.Y));
            }
            return false; //nope nope nope
        }
    }
}
