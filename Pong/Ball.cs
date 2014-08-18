using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong {
    public class Ball : IGameObject {
        private Vector2 position;
        private Vector2 originalPosition;
        private Texture2D texture;
        private Vector2 direction;
        private Vector2 speed;

        private Random rand = new Random();

        public Vector2 Position {
            get { return position; }
        }

        public Vector2 Direction {
            get { return direction; }
        }
        
        public int Height { get { return texture.Height; } }

        public Rectangle BoundingBox {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public Ball(Texture2D texture2D, Vector2 position) {
            this.texture = texture2D;
            this.position = position;
            this.originalPosition = position;

            SetDefaultSpeed();
            SetRandomDirection();
        }

        public void Reset() {
            position = new Vector2(originalPosition.X, originalPosition.Y);
            SetDefaultSpeed();
            SetRandomDirection();
        }

        public void ReverseYDirection() {
            direction.Y = -direction.Y;
        }
        
        public void SetPosition(int x, int y) {
            this.position.X = x;
            this.position.Y = y;
        }

        public void Bounce(Paddle paddle) {
            float differenceToTargetCenter = paddle.BoundingBox.Center.Y - BoundingBox.Center.Y;

            direction = Calc2D.GetRightPointingAngledPoint((int)(90 + (differenceToTargetCenter * 1.3f)));
            
            if (paddle.BoundingBox.Center.X > BoundingBox.Center.X)
                direction.X = -direction.X;

            speed *= 1.04f;
        }

        public void Update(GameTime gameTime) {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }

        private void SetDefaultSpeed() {
            speed = new Vector2(0.4f, 0.4f);
        }

        private void SetRandomDirection() {
            // Get a random angle pointing right from 55 to 125 degrees
            direction = Calc2D.GetRightPointingAngledPoint(rand.Next(55, 125));
            if (rand.Next(2) == 1)
                direction = -direction;
        }
    }
}
