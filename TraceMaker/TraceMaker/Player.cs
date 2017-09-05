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
        
        private const float gforce = 0.1f;
        private readonly Collider collider;
        private const float moveLength = 3;
        private Vector2 move;
        private bool jmp;
        private Animatrix animatrix;

        public Player(Texture2D[] _textures, Vector2 _zero, Point _frameSize) : base( null, _zero)
        {
            position = new Vector2(GS.I.tileMap.GetStartPoint(0).X, GS.I.tileMap.GetStartPoint(0).Y - _frameSize.Y + GS.I.tileMap.GetSize().Y-0.5f );
            collider = new Collider(_frameSize);
            move = Vector2.Zero;
            jmp = true;
            animatrix =new Animatrix(_frameSize, 100, _textures);
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
                move.X -= moveLength;
                animatrix.SetDirection(Directions.LEFT);
            }
            if (key.IsKeyDown(Keys.D))
            {
                move.X += moveLength;
                animatrix.SetDirection(Directions.RIGHT);
            }
            if (!jmp && key.IsKeyDown(Keys.Space))
            {
                move.Y -= 3;
                jmp = true;
            }

            //collision block
            if ( collider.Horizontal(move.X, position))
            {
                move.X = 0;
                
            }
            if (collider.Vertical(move.Y, position))
            {
                move.Y = 0;
                jmp = false;
                animatrix.SetAnimationState(AnimationState.IDLE);
            }

            if (move.X != 0)
                animatrix.SetAnimationState(AnimationState.RUN);

            if (jmp)
                animatrix.SetAnimationState(AnimationState.JUMP);

            position += move;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            animatrix.Draw(spriteBatch, position);
        }

        public  override void Update(GameTime gameTime)
        {
            KeyboardInput();
            animatrix.Update(gameTime);
        }
    }
}
