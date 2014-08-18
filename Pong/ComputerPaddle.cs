using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong {
    public class ComputerPaddle : Paddle {
        private Vector2 ballPosition;
        private Vector2 ballDirection;
        private float maxSpeed = 0.25f;

        public int Score { get; set; }

        public ComputerPaddle(Texture2D texture2D, Vector2 position)
            : base(texture2D, position) {
            this.speed = 0;
        }

        public override void Update(GameTime gameTime) {
            if (this.ballDirection.X < 0) {
                this.direction = new Vector2(0, 0);
                this.speed = 0;
                return;
            }
            else if (this.ballPosition.Y + 10 < BoundingBox.Center.Y - 10) { // ball center is above = move up
                this.speed += 0.05f;
                if (speed > maxSpeed)
                    speed = maxSpeed;
                this.direction = new Vector2(0, -1);
                System.Diagnostics.Debug.WriteLine("up - " + (this.ballPosition.Y + 10) + ", this Y - " + BoundingBox.Center.Y);
            }
            else if (this.ballPosition.Y + 10 > BoundingBox.Center.Y + 10) { // ball center is below
                this.speed += 0.05f;
                if (speed > maxSpeed)
                    speed = maxSpeed;
                this.direction = new Vector2(0, 1);
                System.Diagnostics.Debug.WriteLine("down - " + (this.ballPosition.Y + 10) + ", this Y - " + BoundingBox.Center.Y);
            }
            else if (speed > 0) {
                speed -= 0.05f;
                if (speed < 0.1f)
                    speed = 0;
            }

            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void UpdateBallPosition(Vector2 ballPosition, Vector2 ballDirection) {
            this.ballPosition = ballPosition;
            this.ballDirection = ballDirection;
        }

        /*
         * if (KeyState.IsKeyDown(Keys.W)) {
                this.speed += 0.05f;
                if(speed > maxSpeed)
                    speed = maxSpeed;
                this.direction = new Vector2(0, -1);
            }
            else if (KeyState.IsKeyDown(Keys.S)) {
                this.speed += 0.05f;
                if(speed > maxSpeed)
                    speed = maxSpeed;
                this.direction = new Vector2(0, 1);
            } else if(speed > 0) {
                speed -= 0.05f;
                if (speed < 0.1f)
                    speed = 0;
            }
         * */
    }
}
