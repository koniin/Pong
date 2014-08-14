using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Pong
{
    public class PlayerPaddle : Paddle
    {
        public int Score { get; set; }

        public PlayerPaddle(Texture2D texture2D, Vector2 position)
            : base(texture2D, position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void HandleInput(KeyboardState KeyState)
        {
            if (KeyState.IsKeyDown(Keys.W))
            {
                this.speed = new Vector2(0, 0.3f);
                this.direction = new Vector2(0, -1);
            }
            else if (KeyState.IsKeyDown(Keys.S))
            {
                this.speed = new Vector2(0, 0.3f);
                this.direction = new Vector2(0, 1);
            }
            else
                speed = speed / 2;
        }
    }
}
