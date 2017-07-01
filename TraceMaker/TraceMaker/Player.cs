﻿using System;
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

        public Player(Texture2D _texture, Vector2 _zero, Point _frameSize) : base(_texture, _zero)
        {
            position = new Vector2(GS.I.tileMap.GetStartPoint().X, GS.I.tileMap.GetStartPoint().Y - texture.Height + GS.I.tileMap.GetSize().Y-0.5f );
            collider = new Collider(_frameSize);
            move = Vector2.Zero;
            jmp = true;
            animatrix=new Animatrix(_frameSize, new Point(_texture.Width / _frameSize.X, (_texture.Height / _frameSize.Y) - 1),100);
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
            }
            if (key.IsKeyDown(Keys.D))
            {
                move.X += moveLength;
            }
            if (!jmp && key.IsKeyDown(Keys.Space))
            {
                move.Y -= 5;
                jmp = true;
            }

            //collision block
            if ( collider.ColHor(move.X, position))
            {
                move.X = 0;
            }
            if (collider.ColVer(move.Y, position))
            {
                move.Y = 0;
                jmp = false;
            }

            position += move;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animatrix.GetFrameRectangle() ,Color.White);
        }

        public  override void Update(GameTime gameTime)
        {
            KeyboardInput();
            animatrix.Update(gameTime);
        }
    }
}
