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

        public int Score { get; set; }

        public ComputerPaddle(Texture2D texture2D, Vector2 position)
            : base(texture2D, position) {
            this.speed = 0.28f;
            type = PaddleType.Computer;
        }

        public override void Update(GameTime gameTime) {
            if (this.ballDirection.X < 0)
                return;
            /*
            if (this.BoundingBox.Center.Y > this.ballPosition.Y)
                this.direction = new Vector2(0, -1);
            else if (this.BoundingBox.Center.Y < this.ballPosition.Y)
                this.direction = new Vector2(0, 1);
            else
                this.direction = new Vector2(0, 0);
            */

            /*
             *  Works better but ugly
             */ 
            float ballY = 0;
            if (this.ballDirection.Y >= 0)
                ballY = this.ballPosition.Y + 50;
            else
                ballY = this.ballPosition.Y - 50;

            if (this.ballDirection.X < 0)
                return;
            else if (ballY > this.Position.Y - 10 && ballY < this.Position.Y + 90)
                return;
            else if (ballY > this.Position.Y)
                this.direction = new Vector2(0, 1);
            else if (ballY < this.Position.Y + 90)
                this.direction = new Vector2(0, -1);
            
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void UpdateBallPosition(Vector2 ballPosition, Vector2 ballDirection) {
            this.ballPosition = ballPosition;
            this.ballDirection = ballDirection;
        }
    }
}
