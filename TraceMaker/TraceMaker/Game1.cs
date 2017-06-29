using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraceMaker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            GS.I._tileMap= new TileMap(new Texture2D[]{
                Content.Load<Texture2D>("tileWhite"),
                Content.Load<Texture2D>("tileBlack"),
                Content.Load<Texture2D>("tileBrown"),
                Content.Load<Texture2D>("tileBlue"),
                Content.Load<Texture2D>("tileGray"),
                Content.Load<Texture2D>("tileGreen"),
                Content.Load<Texture2D>("tileOrange"),
                Content.Load<Texture2D>("tilePink"),
                Content.Load<Texture2D>("tileYellow"),
                Content.Load<Texture2D>("tileRed")    },
                Content.Load<Texture2D>("bitmap001"));
            GS.I._player= new Player(Content.Load<Texture2D>("blue1"), new Vector2(16,16));
            GS.I._camera = new Camera(GraphicsDevice.Viewport);

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

            GS.I._player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            spriteBatch.Begin(transformMatrix: GS.I._camera.GetViewMatrix());
           
            GS.I._tileMap.Draw(spriteBatch);
            GS.I._player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
