using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong {
    public class Paddle : IGameObject {
        private Texture2D texture;
        protected Vector2 position;
        protected Vector2 direction;
        protected float speed;

        public int Height { get { return texture.Height; } }

        public Vector2 Position {
            get { return position; }
        }

        public Rectangle BoundingBox {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public Paddle(Texture2D texture2D, Vector2 position) {
            this.texture = texture2D;
            this.position = position;
        }

        public virtual void Update(GameTime gameTime) {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void SetPosition(int y) {
            this.position.Y = y;
        }
    }
}
