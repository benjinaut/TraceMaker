using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraceMaker
{
    class Player : GameObject
    {
        private Collider _collider;
        private Vector2 _move;

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            _collider = new Collider(texture.Bounds.Size);
            _move = Vector2.Zero;
        }


        void KeyboardInput()
        {
            KeyboardState key = Keyboard.GetState();
            _move = Vector2.Zero;

            //key block
            if (key.IsKeyDown(Keys.W))
            {
                _move.Y -= 1;
            }
            if (key.IsKeyDown(Keys.A))
            {
                _move.X -= 1;
            }
            if (key.IsKeyDown(Keys.S))
            {
                _move.Y += 1;
            }
            if (key.IsKeyDown(Keys.D))
            {
                _move.X += 1;
            }
            if (key.IsKeyDown(Keys.E))
            {
                
            }
            _move.Normalize();

            //collision block
            if (_move.X != 0 && _collider.ColHor(_move.X, _position))
            {
                _move.X = 0;
            }
            if (_move.Y != 0 && _collider.ColVer(_move.Y, _position))
            {
                _move.Y = 0;
            }

            _position += _move;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public  override void Update(GameTime gameTime)
        {
            KeyboardInput();
        }
    }
}
