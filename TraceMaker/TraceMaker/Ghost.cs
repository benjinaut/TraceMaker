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
    class Ghost : GameObject // for debugging
    {

        private Vector2 move;
        private Animatrix animatrix;
        private const float moveLength = 3;
        

        public Ghost(Texture2D _textures, Vector2 _zero, Point _frameSize) : base(_textures,_zero)
        {
            position = new Vector2(GS.I.tileMap.GetStartPoint().X, GS.I.tileMap.GetStartPoint().Y - _frameSize.Y + GS.I.tileMap.GetSize().Y - 0.5f);
            move = Vector2.Zero;
            animatrix = new Animatrix(_frameSize, 100, new Texture2D[] {_textures});


        }

        void KeyboardInput()
        {
            KeyboardState key = Keyboard.GetState();
            move = Vector2.Zero;
            //key block
            if (key.IsKeyDown(Keys.A))
            {
                move.X -= moveLength;
                animatrix.SetDirection(Directions.LEFT);
            }
            if (key.IsKeyDown(Keys.D))
            {
                move.X += moveLength;
                animatrix.SetDirection(Directions.RIGHT);
            }
            if (key.IsKeyDown(Keys.W))
            {
                move.Y -= moveLength;
            }
            if (key.IsKeyDown(Keys.S))
            {
                move.Y += moveLength;
            }
            //collision block

            position += move;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            animatrix.Draw(spriteBatch, position);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardInput();
            animatrix.Update(gameTime);
        }
    }
}
