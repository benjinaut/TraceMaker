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
        private Point currentFrame;
        private readonly Point frameSize;
        private Point sheetSize;
        private int tslf = 0; //time since last frame
        private int mpf; //milliseconds per frame

        public Animatrix(Point _frameSize, Point _sheetSize, int _mpf)
        {
            currentFrame = Point.Zero;
            frameSize = _frameSize;
            sheetSize = _sheetSize;
            mpf = _mpf;
        }

        public Rectangle GetFrameRectangle()
        {
            return new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y);
        }

        public void Update(GameTime gameTime)
        {
            tslf += gameTime.ElapsedGameTime.Milliseconds;
            if (tslf > mpf)
            {
                tslf -= mpf;
                currentFrame.X++;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                }
            }
        }
    }
}
