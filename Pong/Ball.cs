using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public class Ball : IGameObject
    {
        private Vector2 position;
        private Vector2 originalPosition;
        private Texture2D texture;
        private Vector2 direction;
        private Vector2 speed;

        private Random rand = new Random();

        public Vector2 Position
        {
            get { return position; }
        }

        public Ball(Texture2D texture2D, Vector2 position)
        {
            this.texture = texture2D;
            this.position = position;
            this.originalPosition = position;

            SetRandomDirection();
            speed = new Vector2(200, 200);
        }

        public void Reset()
        {
            position = new Vector2(originalPosition.X, originalPosition.Y);
            SetRandomDirection();
        }

        public void ReverseY()
        {
            direction.Y = -direction.Y;
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        private void SetRandomDirection()
        {
            direction = GetRandomDirection2D();
        }

        private Vector2 GetRandomDirection2D()
        {
            double azimuth = rand.NextDouble() * 2 * 3.14;
            return new Vector2((float)Math.Cos(azimuth), (float)Math.Sin(azimuth));
        }
    }
}
