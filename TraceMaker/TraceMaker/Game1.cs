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
            // TODO: Add your initialization logic here
            GS.I._tileMap= new TileMap(new Texture2D[]{Content.Load<Texture2D>("tileWhite"),
                                                       Content.Load<Texture2D>("tileBlack"),
                                                       Content.Load<Texture2D>("tileBrown"),
                                                       Content.Load<Texture2D>("tileBlue"),
                                                       Content.Load<Texture2D>("tileGray"),
                                                       Content.Load<Texture2D>("tileGreen"),
                                                       Content.Load<Texture2D>("tileOrange"),
                                                       Content.Load<Texture2D>("tilePink"),
                                                       Content.Load<Texture2D>("tileYellow"),
                                                       Content.Load<Texture2D>("tileRed")
                                                       }, Content.Load<Texture2D>("bitmapCollision001"));
            GS.I._player=new Player(Content.Load<Texture2D>("Blue1"), new Vector2(100,100));
            GS.I._camera = new Camera(GraphicsDevice.Viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            GS.I._player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(transformMatrix: GS.I._camera.GetViewMatrix());
            GS.I._tileMap.Draw(spriteBatch);
            GS.I._player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
