#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Ball ball;
        private ScoreScreen score;
        private PlayerPaddle player;
        private ComputerPaddle computer;

        private SpriteFont font;
        
        private int gameWidth = 800;
        private int gameHeight = 600;

        private int playerLeftScore = 0;
        private int playerRightScore = 0;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = gameWidth;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = gameHeight;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = CreateTexture();
            font = Content.Load<SpriteFont>("testfont");

            ball = new Ball(texture, new Vector2(390, 290));
            score = new ScoreScreen(font, new Vector2(gameWidth * 0.25F, gameHeight * 0.45F), new Vector2(gameWidth * 0.75F, gameHeight * 0.45F));

            throw new NotImplementedException("paddle texture");
            throw new NotImplementedException("player and computer paddle");
        }
        /*
        protected Texture2D CreateTexture()
        {
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            texture.SetData<Color>(new Color[] { Color.White });
            return texture;
        }*/

        private Texture2D CreateTexture()
        {
            Color[] foregroundColors = new Color[20 * 20];

            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    foregroundColors[x + y * 20] = Color.White;
                }
            }

            Texture2D texture = new Texture2D(GraphicsDevice, 20, 20, false, SurfaceFormat.Color);
            texture.SetData(foregroundColors);
            return texture;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            texture.Dispose();
            font = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            throw new NotImplementedException("input handling for player");

            ball.Update(gameTime);

            checkCollisions();

            score.Update(playerLeftScore.ToString(), playerRightScore.ToString());

            base.Update(gameTime);
        }

        private void checkCollisions()
        {
            if (ball.Position.X > gameWidth) 
            {
                computer.Score++;
                ball.Reset();
            }
            else if (ball.Position.X < 0) 
            {
                player.Score++;
                ball.Reset();
            }
            else if (ball.Position.Y > gameHeight - 20 || ball.Position.Y < 0)
            {
                ball.ReverseY();
            }
            
            throw new NotImplementedException("Paddle collision");
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            score.Draw(spriteBatch);

            ball.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
