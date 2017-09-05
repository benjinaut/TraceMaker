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
        public Animation animation;
        private Texture2D[] spriteSheet;
        private AnimationState animationState;
        private Directions direction;
        private Dictionary<AnimationState, Texture2D> spriteDictionary;

        public Animatrix(Point _frameSize, int _mpf, Texture2D[] _spriteSheets)
        {
            spriteSheet = _spriteSheets;
            animation = new Animation(_frameSize, (_spriteSheets[0].Bounds.Size.X/_frameSize.X), _mpf, AnimationState.IDLE, Directions.RIGHT);
            animationState=AnimationState.IDLE;
            direction = Directions.RIGHT;
            spriteDictionary =new Dictionary<AnimationState, Texture2D>();
            spriteDictionary.Add(AnimationState.IDLE, _spriteSheets[0]);
            spriteDictionary.Add(AnimationState.RUN, _spriteSheets[1]);
            spriteDictionary.Add(AnimationState.JUMP, _spriteSheets[2]);

        }


        public void SetAnimationState(AnimationState _animationState)
        {
            animationState = _animationState;
        }
        public void SetDirection(Directions _direction)
        {
            direction = _direction;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if(direction==Directions.LEFT)
                spriteBatch.Draw(spriteDictionary[animationState], position, null, animation.GetFrameRectangle(), Vector2.Zero, 0, null/**/, null, SpriteEffects.FlipHorizontally, 0);
            else
                spriteBatch.Draw(spriteDictionary[animationState], position, null, animation.GetFrameRectangle(), Vector2.Zero, 0, null, null, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        { 
            animation.Update(gameTime, animationState, spriteDictionary[animationState].Width);
        }

    }
}
