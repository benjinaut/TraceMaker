using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TraceMaker
{
    interface IGameState 
    {
        void Init();
        void Loadcontent(ContentManager content);
        EGameState Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Unloadcontent();
    }
}
