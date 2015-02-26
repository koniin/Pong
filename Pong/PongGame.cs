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

namespace Pong {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PongGame : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameObjects gameObjects;
        private Texture2D dividerTexture;
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

            dividerTexture = TextureManager.CreateTexture(GraphicsDevice, 20, 20);

            font = Content.Load<SpriteFont>("Consolas78");
            
            soundManager = new SoundManager(Content);
            soundManager.EnableSound(true);
            soundManager.AddSound("ping");
            soundManager.AddSound("bell");
            soundManager.AddMusic("drums", true, 0.5f);
            soundManager.PlayMusic();

            var bounds = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            
            gameObjects = new GameObjects {
                PlayerPaddle = new PlayerPaddle(TextureManager.CreateTexture(GraphicsDevice, 20, 100), new Vector2(20, gameHeight / 2 - 50), bounds),
                ComputerPaddle = new ComputerPaddle(TextureManager.CreateTexture(GraphicsDevice, 20, 100), new Vector2(gameWidth - 40, gameHeight / 2 - 50), bounds),
                Ball = new Ball(TextureManager.CreateTexture(GraphicsDevice, 20, 20), new Vector2(390, 290), bounds),
                SoundManager = soundManager,
                Score = new ScoreScreen(font, new Vector2(gameWidth * 0.40F, 20), new Vector2(gameWidth * 0.55F, 20))
            };
        }

        protected override void UnloadContent() {
            soundManager.StopMusic();
            soundManager = null;
            gameObjects.Dispose();
            dividerTexture.Dispose();
            font = null;
            Content.Unload();
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameObjects.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            DrawDivider(spriteBatch);
            gameObjects.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawDivider(SpriteBatch spriteBatch) {
            // To optimize: pre-calculate positions or make one big sprite
            for (int i = 0; i < gameHeight / 30; i++) {
                spriteBatch.Draw(dividerTexture, new Vector2(gameWidth / 2 - 10, (i * 30) + 10), Color.White);
            }
        }
    }
}
