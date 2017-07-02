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
    enum AnimationState
    {
        IDLE, RUN, JUMP 
    }
    

    class Animatrix
    {
        //int mps kann in animatrix
        private Animation animation;
        private Texture2D[] spriteSheet;
        private AnimationState animationState;
        private Dictionary<AnimationState, Texture2D> spriteDictionary;

        public Animatrix(Point _frameSize, int _mpf, Texture2D[] _spriteSheets)
        {
            spriteSheet = _spriteSheets;
            animation = new Animation(_frameSize, (_spriteSheets[0].Bounds.Size.X/_frameSize.X), _mpf, AnimationState.IDLE);
            animationState = AnimationState.IDLE;
            spriteDictionary=new Dictionary<AnimationState, Texture2D>();
            spriteDictionary.Add(AnimationState.IDLE, _spriteSheets[0]);
            spriteDictionary.Add(AnimationState.RUN, _spriteSheets[1]);
            spriteDictionary.Add(AnimationState.JUMP, _spriteSheets[2]);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(spriteDictionary[animationState], position, animation.GetFrameRectangle(), Color.White);
        }

        public void Update(GameTime gameTime, AnimationState _animationState)
        {
            animationState = _animationState;
            animation.Update(gameTime, animationState, spriteDictionary[animationState].Width);
        }

    }
}
