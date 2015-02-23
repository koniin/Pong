using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong {
    public class ComputerPaddle : Sprite {
        private Vector2 ballPosition;
        private Vector2 ballDirection;
        private Vector2 maxSpeed = new Vector2(0.25f);

        public int Score { get; set; }

        public ComputerPaddle(Texture2D texture2D, Vector2 position, Rectangle screenBounds)
            : base(texture2D, position, screenBounds) 
        {
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects) 
        {
            if (this.ballDirection.X < 0) {
                this.direction = new Vector2(0, 0);
                Velocity = Vector2.Zero;
                return;
            }
            else if (this.ballPosition.Y + 10 < BoundingBox.Center.Y - 10) { // ball center is above = move up
                Velocity += new Vector2(0.05f);
                if (Velocity.Y > maxSpeed.Y)
                    Velocity = maxSpeed;
                this.direction = new Vector2(0, -1);
            }
            else if (this.ballPosition.Y + 10 > BoundingBox.Center.Y + 10) { // ball center is below
                Velocity += new Vector2(0.05f);
                if (Velocity.Y > maxSpeed.Y)
                    Velocity = maxSpeed;
                this.direction = new Vector2(0, 1);
            }
            else if (Velocity.Y > 0) {
                Velocity -= new Vector2(0.05f);
                if (Velocity.Y < 0.1f)
                    Velocity = Vector2.Zero;
            }

            position += direction * Velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            CheckBounds(gameObjects);
        }

        public void UpdateBallPosition(Vector2 ballPosition, Vector2 ballDirection) 
        {
            this.ballPosition = ballPosition;
            this.ballDirection = ballDirection;
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
