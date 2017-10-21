using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TraceMaker
{
    class Animation1
    {
        private EAnimationState animationState;
        private int currentFrame;
        private readonly Point frameSize;
        private int sheetSize;
        private int tslf = 0; //time since last frame
        private int mpf; //milliseconds per frame 


        private Dictionary<EAnimationState, Point> animationLimits;
        private Dictionary<EAnimationState, int> animationTimes;
        private Dictionary<EAnimationState, EAnimationState> next;

        public Animation1(Point _frameSize, int _sheetSize, int _mpf, EAnimationState _animationState, Directions _direction)
        {
            animationState = _animationState;
            currentFrame = 0;
            frameSize = _frameSize;
            sheetSize = _sheetSize;
            mpf = _mpf;
        }

        public Rectangle GetFrameRectangle()
        {
            return new Rectangle(currentFrame * frameSize.X, 0, frameSize.X, frameSize.Y);
        }
        
        public void Update(GameTime gameTime, EAnimationState _animationState, int _sheetSizeXFrameSize)
        {
            if (animationState != _animationState)
            {
                animationState = _animationState;
                currentFrame = 0;
                sheetSize = _sheetSizeXFrameSize/frameSize.X;
            }
            else
            {
                tslf += gameTime.ElapsedGameTime.Milliseconds;
                if (tslf > mpf)
                {
                    tslf -= mpf;
                    currentFrame++;
                    if (currentFrame >= sheetSize)
                    {
                        currentFrame = 0;
                    }
                }
            }




        }
    }
}
