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

        private float gforce = 0.1f;

        private readonly Collider collider;
        private Vector2 move;
        private bool jmp;

        public Player(Texture2D _texture, Vector2 _position) : base(_texture, _position)
        {
            collider = new Collider(_texture.Bounds.Size);
            move = Vector2.Zero;
            jmp = true;
        }


        void KeyboardInput()
        {
            KeyboardState key = Keyboard.GetState();
            move.X = 0;
            if (move.Y < GS.I.tileMap.GetSize().Y)
            {
                move.Y += gforce;
            }
            //key block
            if (key.IsKeyDown(Keys.A))
            {
                move.X -= 1;
            }
            if (key.IsKeyDown(Keys.D))
            {
                move.X += 1;
            }


            if(move.Length()>0)
            move.Normalize();

            //collision block
            if ( collider.ColHor(move.X, position))
            {
                move.X = 0;
            }
            if (collider.ColVer(move.Y, position))
            {
                move.Y = 0;
            }

            position += move;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public  override void Update(GameTime gameTime)
        {
            KeyboardInput();
        }
    }
}
