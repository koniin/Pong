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

        private GameObjects gameObjects;
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
        protected override void Initialize() {
            base.Initialize();
        }
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

            var bounds = new Rectangle(0, 0, Window.ClientBounds.Width,
                    Window.ClientBounds.Height);

            score = new ScoreScreen(font, new Vector2(gameWidth * 0.40F, 20), new Vector2(gameWidth * 0.55F, 20));
            ball = new Ball(ballTexture, new Vector2(390, 290),
                bounds);
            player = new PlayerPaddle(paddleTexture, new Vector2(20, gameHeight / 2 - 50), 
                bounds);
            computer = new ComputerPaddle(paddleTexture, new Vector2(gameWidth - 40, gameHeight / 2 - 50),
                bounds);

            gameObjects = new GameObjects
            {
                PlayerPaddle = player,
                ComputerPaddle = computer,
                Ball = ball,
                SoundManager = soundManager
            };
        }
        protected override void UnloadContent() {
            soundManager.StopMusic();
            soundManager = null;


            ballTexture.Dispose();
            paddleTexture.Dispose();
            font = null;

            Content.Unload();
        }
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ball.Update(gameTime, gameObjects);
            player.Update(gameTime, gameObjects);
            computer.Update(gameTime, gameObjects);
            computer.UpdateBallPosition(ball.Position, ball.Direction);
            score.Update(computer.Score.ToString(), player.Score.ToString());

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            DrawDivider(spriteBatch);
            score.Draw(spriteBatch);
            player.Draw(spriteBatch);
            computer.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawDivider(SpriteBatch spriteBatch) {
            // To optimize: pre-calculate positions or make one big sprite
            for (int i = 0; i < gameHeight / 30; i++) {
                spriteBatch.Draw(ballTexture, new Vector2(gameWidth / 2 - 10, (i * 30) + 10), Color.White);
            }
        }
    }
}
