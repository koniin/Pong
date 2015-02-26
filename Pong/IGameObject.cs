using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong {
    interface IGameObject {
        Rectangle BoundingBox { get; }
        void Update(GameTime gameTime, GameObjects gameObjects);
        void Draw(SpriteBatch spriteBatch);
    }
}
