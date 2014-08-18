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

        public int Score { get; set; }

        public ComputerPaddle(Texture2D texture2D, Vector2 position)
            : base(texture2D, position) {
            this.speed = 0.28f;
            type = PaddleType.Computer;
        }

        public override void Update(GameTime gameTime) {
            if (this.ballDirection.X < 0) {
                this.direction = new Vector2(0, 0);
                return;
            } else if (this.ballPosition.Y + 10 < this.BoundingBox.Center.Y) // ball center is above
                this.direction = new Vector2(0, -1);
            else if (this.ballPosition.Y + 10 > this.BoundingBox.Center.Y) // ball center is below
                this.direction = new Vector2(0, 1);

            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void UpdateBallPosition(Vector2 ballPosition, Vector2 ballDirection) {
            this.ballPosition = ballPosition;
            this.ballDirection = ballDirection;
        }
    }
}
