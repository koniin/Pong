using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public class Paddle : IGameObject
    {
        private Vector2 position;
        private Texture2D texture;

        private Vector2 direction;
        private Vector2 speed;

        public Paddle(Texture2D texture2D, Vector2 position) 
        {
            this.texture = texture2D;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
