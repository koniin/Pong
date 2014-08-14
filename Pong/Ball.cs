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

        public Vector2 Direction
        {
            get { return direction; }
        }

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public Ball(Texture2D texture2D, Vector2 position)
        {
            this.texture = texture2D;
            this.position = position;
            this.originalPosition = position;

            SetRandomDirection();
            speed = new Vector2(0.3f, 0.3f);
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

        public void Bounce(Rectangle collisionTarget)
        {
            direction.X = -direction.X;

            int differenceToTargetCenter = collisionTarget.Center.Y - BoundingBox.Center.Y;

            throw new NotImplementedException("Get a real direction calcualation....");

            if (differenceToTargetCenter > 20)
            {
                direction.Y = -direction.Y * 1.9f;
            }
            else if (differenceToTargetCenter <= 20 && differenceToTargetCenter >= -20)
            {
                direction.Y = 0.5f;
            }
            else if (differenceToTargetCenter < -20)
            {
                direction.Y = -direction.Y * 1.9f;
            }
            else
            {
                throw new NotImplementedException();
            }

            /*
                collisionTarget.Center.Y - BoundingBox.Center.Y
             
                50 - 20 = 30 (högt upp)

                185 - 188 = -3 (nära mitten)

                494 - 551 = -57 (långt ner)
             * */
            /*
            if(position.Y < collisionTarget.Y + 33)
            if(position.Y < collisionTarget.Y + 66)
            if(position.Y < collisionTarget.Y + 100)
            */
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
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
