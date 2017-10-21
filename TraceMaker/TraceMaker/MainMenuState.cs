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
    class MainMenuState : IGameState
    {
        Button butt1;


        public void Init()
        {
            Console.WriteLine("fick dich matthis");
        }

        public void Loadcontent(ContentManager content)
        {
            butt1 = new Button(new Rectangle(new Point(40, 40), new Point(200, 200)), Init, content.Load<Texture2D>("tileOrange")); //TODO hier weiter machen
            
        }

        public EGameState Update(GameTime gameTime)
        {
            butt1.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                return EGameState.INGAME;
            }
            return EGameState.MAINMENU;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            butt1.Draw(spriteBatch);
        }

        public void Unloadcontent()
        {
            Console.WriteLine("fick dich matthis zum zweiten mal");
        }
    }
}
