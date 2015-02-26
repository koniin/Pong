using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Pong {
    public class PlayerPaddle : Sprite {
        private Vector2 maxSpeed = new Vector2(0.3f);
        public int Score { get; set; }

        public PlayerPaddle(Texture2D texture2D, Vector2 position, Rectangle screenBounds)
            : base(texture2D, position, screenBounds) 
        {
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects) 
        {
            position += direction * Velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            HandleInput(Keyboard.GetState());

            CheckBounds(gameObjects);
        }

        public void HandleInput(KeyboardState KeyState) 
        {
            if (KeyState.IsKeyDown(Keys.W)) {
                Velocity += new Vector2(0.05f);
                if (Velocity.Y > maxSpeed.Y)
                    Velocity = maxSpeed;
                this.direction = new Vector2(0, -1);
            }
            else if (KeyState.IsKeyDown(Keys.S)) {
                Velocity += new Vector2(0.05f);
                if (Velocity.Y > maxSpeed.Y)
                    Velocity = maxSpeed;
                this.direction = new Vector2(0, 1);
            }
            else if (Velocity.Y > 0)
            {
                Velocity -= new Vector2(0.05f);
                if (Velocity.Y < 0.1f)
                    Velocity = Vector2.Zero;
            }
        }
        protected override void CheckBounds(GameObjects gameObjects)
        {
            if (Position.Y + Height > screenBounds.Height)
                SetPosition(screenBounds.Height - Height);
            else if (Position.Y < 0)
                SetPosition(0);
        }
    }
}
