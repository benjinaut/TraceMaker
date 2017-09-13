using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraceMaker
{
    enum AnimationState
    {
        IDLE, RUN, JUMP
    }
    enum Directions
    {
        RIGHT, LEFT
    }

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
            GS.I.tileMap= new TileMap(new Texture2D[]{
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
                Content.Load<Texture2D>("Unbenannt"));
            GS.I.player= new Player(new Texture2D[]
                {
                    Content.Load<Texture2D>("traceMakerSprite-0001"),
                    Content.Load<Texture2D>("traceMakerSprite-0002"),
                    Content.Load<Texture2D>("traceMakerSprite-0003")
                }
                , Vector2.Zero, new Point(50,50));
            GS.I.camera = new Camera(GraphicsDevice.Viewport);

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

            GS.I.player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin(transformMatrix: GS.I.camera.GetViewMatrix());
           
            GS.I.tileMap.Draw(spriteBatch);
            GS.I.player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
