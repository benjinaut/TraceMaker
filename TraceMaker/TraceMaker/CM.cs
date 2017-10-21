using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TraceMaker
{
    class CM //Content manager stuff singleton
    {
        public static CM i;

        public Texture2D[] Mapes;
        public Texture2D[] tiles;
        public Texture2D[] SpriteSheets;

        

        

        public static CM I
        {
            get
            {
                if (i == null)
                    i = new CM();
                return i;
            }
        }
    }
}
