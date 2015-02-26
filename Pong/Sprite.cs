using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong {
    public abstract class Sprite : IGameObject 
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 direction;
        protected Rectangle screenBounds;
        public Sprite(Texture2D texture, Vector2 location, Rectangle screenBounds) {
            this.texture = texture;
            this.position = location;
            Velocity = Vector2.Zero;
            this.screenBounds = screenBounds;
        }
        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            position += direction * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        protected abstract void CheckBounds(GameObjects gameObjects);
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public int Width { get { return texture.Width; } }
        public int Height { get { return texture.Height; } }

        public Vector2 Velocity { get; protected set; }
        public Vector2 Position {
            get { return position; }
        }
        public Vector2 Direction
        {
            get { return direction; }
        }
        public Rectangle BoundingBox {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }
        public void SetPosition(int y) {
            this.position.Y = y;
        }
        public void Dispose()
        {
            if(!texture.IsDisposed)
                texture.Dispose();  
        }
    }
}
