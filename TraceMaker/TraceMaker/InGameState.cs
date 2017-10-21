using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraceMaker
{
    class InGameState : IGameState
    {
        public void Init()
        {
            Console.WriteLine("matthis hat nen kleinen");
        }

        public void Loadcontent(ContentManager content)
        {

        }

        public EGameState Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                return EGameState.MAINMENU;
            }
            return EGameState.INGAME;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Unloadcontent()
        {
            Console.WriteLine("penis");
        }
    }
}
