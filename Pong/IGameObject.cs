using System;
namespace Pong
{
    interface IGameObject
    {
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
        void Update(Microsoft.Xna.Framework.GameTime gameTime);
    }
}
