using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Pong {
    public class PlayerPaddle : Paddle {
        private float maxSpeed = 0.3f;

        public int Score { get; set; }

        public PlayerPaddle(Texture2D texture2D, Vector2 position)
            : base(texture2D, position) {
        }

        public override void Update(GameTime gameTime) {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void HandleInput(KeyboardState KeyState) {
            if (KeyState.IsKeyDown(Keys.W)) {
                this.speed += 0.05f;
                if(speed > maxSpeed)
                    speed = maxSpeed;
                this.direction = new Vector2(0, -1);
            }
            else if (KeyState.IsKeyDown(Keys.S)) {
                this.speed += 0.05f;
                if(speed > maxSpeed)
                    speed = maxSpeed;
                this.direction = new Vector2(0, 1);
            } else if(speed > 0) {
                speed -= 0.05f;
                if (speed < 0.1f)
                    speed = 0;
            }
        }
    }
}
