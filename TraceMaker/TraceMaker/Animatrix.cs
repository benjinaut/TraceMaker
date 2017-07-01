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

        private Animation[] animations;
        private AnimationState animationState;

        public Animatrix(Point _frameSize, int _mpf, Texture2D[] _spriteSheets)
        {
            animations=new Animation[_spriteSheets.Length];
            for (int i = 0; i< _spriteSheets.Length; i++)
            {
                animations[i]=new Animation(_frameSize, _spriteSheets[i].Bounds.Size, _mpf);        
            }

        }


    }
}
