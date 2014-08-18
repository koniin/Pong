#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
#endregion

namespace Pong {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PongGame : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D ballTexture;
        private Texture2D paddleTexture;
        private Ball ball;
        private ScoreScreen score;
        private PlayerPaddle player;
        private ComputerPaddle computer;
        private SpriteFont font;
        private SoundManager soundManager;

        private const int gameWidth = 800;
        private const int gameHeight = 600;

        public PongGame()
            : base() {
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
        protected override void Initialize() {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ballTexture = TextureManager.CreateTexture(GraphicsDevice, 20, 20);
            paddleTexture = TextureManager.CreateTexture(GraphicsDevice, 20, 100);
            font = Content.Load<SpriteFont>("Consolas78");
            
            soundManager = new SoundManager(Content);
            soundManager.EnableSound(true);
            soundManager.AddSound("ping");
            soundManager.AddSound("bell");

            soundManager.AddMusic("drums", true, 0.5f);
            soundManager.PlayMusic();

            score = new ScoreScreen(font, new Vector2(gameWidth * 0.25F, gameHeight * 0.40F), new Vector2(gameWidth * 0.70F, gameHeight * 0.40F));
            ball = new Ball(ballTexture, new Vector2(390, 290));
            player = new PlayerPaddle(paddleTexture, new Vector2(20, gameHeight / 2 - 50));
            computer = new ComputerPaddle(paddleTexture, new Vector2(gameWidth - 40, gameHeight / 2 - 50));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            soundManager.StopMusic();
            soundManager = null;

            ballTexture.Dispose();
            paddleTexture.Dispose();
            font = null;

            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.HandleInput(Keyboard.GetState());

            ball.Update(gameTime);
            player.Update(gameTime);
            computer.Update(gameTime);

            computer.UpdateBallPosition(ball.Position, ball.Direction);

            CheckCollisions();

            score.Update(computer.Score.ToString(), player.Score.ToString());

            base.Update(gameTime);
        }

        private void CheckCollisions() {
            CheckBallWorldCollisions();
            CheckWorldCollision(player);
            CheckWorldCollision(computer);
            CheckBallCollision(player);
            CheckBallCollision(computer);
        }

        private void CheckBallWorldCollisions() {
            if (ball.Position.X > gameWidth) {
                soundManager.Play("bell");
                computer.Score++;
                ball.Reset();
            }
            else if (ball.Position.X < 0) {
                soundManager.Play("bell");
                player.Score++;
                ball.Reset();
            }
            else if (ball.Position.Y > gameHeight - ball.Height) {
                soundManager.Play("ping");
                ball.SetPosition(ball.Position.X, gameHeight - ball.Height);
                ball.ReverseYDirection();
            }
            else if(ball.Position.Y < 0) {
                soundManager.Play("ping");
                ball.SetPosition(ball.Position.X, 0);
                ball.ReverseYDirection();
            }
        }

        private void CheckWorldCollision(Paddle paddle) {
            if (paddle.Position.Y + paddle.Height > gameHeight)
                paddle.SetPosition(gameHeight - paddle.Height);
            else if (paddle.Position.Y < 0)
                paddle.SetPosition(0);
        }

        private void CheckBallCollision(Paddle paddle) {
            if (ball.BoundingBox.Intersects(paddle.BoundingBox)) {
                soundManager.Play("ping");
                ball.Bounce(paddle);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            score.Draw(spriteBatch);
            player.Draw(spriteBatch);
            computer.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
