using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceMaker
{
    enum EGameState
    {
        MAINMENU, INGAME
    }



    class Game2 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IGameState gameState;
        EGameState currentGamestate;
        EGameState lastGamestate;




        public Game2()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            currentGamestate = EGameState.MAINMENU;
            lastGamestate = EGameState.MAINMENU;
            gameState = new MainMenuState();
            gameState.Init();
            gameState.Loadcontent(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentGamestate = gameState.Update(gameTime);
            if (currentGamestate != lastGamestate)
            {
                HandleGameState();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();

            gameState.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void HandleGameState()
        {
            gameState.Unloadcontent();

            switch (currentGamestate)
            {
                case EGameState.MAINMENU :
                    gameState = new MainMenuState();
                    break;
                case EGameState.INGAME:
                    gameState = new InGameState();
                    break;
                default: break;

            }

            lastGamestate = currentGamestate;
            gameState.Init();
            gameState.Loadcontent(Content);

        }

    }

}




