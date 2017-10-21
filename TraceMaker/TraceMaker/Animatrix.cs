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
    class Animatrix
    {
        public Animation1 animation;
        private Texture2D[] spriteSheet;
        private EAnimationState animationState;
        private Directions direction;
        private Dictionary<EAnimationState, Texture2D> spriteDictionary;
        private Color color;

        public Animatrix(Point _frameSize, int _mpf, Texture2D[] _spriteSheets)
        {
            spriteSheet = _spriteSheets;
            animation = new Animation1(_frameSize, (_spriteSheets[0].Bounds.Size.X/_frameSize.X), _mpf, EAnimationState.IDLE, Directions.RIGHT);
            animationState=EAnimationState.IDLE;
            direction = Directions.RIGHT;
            spriteDictionary =new Dictionary<EAnimationState, Texture2D>();
            spriteDictionary.Add(EAnimationState.IDLE, _spriteSheets[0]);
            if (_spriteSheets.Length > 1)
            {
                spriteDictionary.Add(EAnimationState.RUN, _spriteSheets[1]);
                spriteDictionary.Add(EAnimationState.JUMP, _spriteSheets[2]);
            }
            color = Color.White;

        }


        public void SetAnimationState(EAnimationState _animationState)
        {
            animationState = _animationState;
        }
        public void SetDirection(Directions _direction)
        {
            direction = _direction;
        }
        public void SetColor(Color _color)
        {
            color = _color;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if(direction==Directions.LEFT)
                spriteBatch.Draw(spriteDictionary[animationState], position, null , animation.GetFrameRectangle(), Vector2.Zero, 0, null, color, SpriteEffects.FlipHorizontally, 0);
            else
                spriteBatch.Draw(spriteDictionary[animationState], position, null, animation.GetFrameRectangle(), Vector2.Zero, 0, null, color, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        { 
            animation.Update(gameTime, animationState, spriteDictionary[animationState].Width);
        }

    }
}
