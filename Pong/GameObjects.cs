using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class GameObjects {
        public PlayerPaddle PlayerPaddle { get; set; }
        public ComputerPaddle ComputerPaddle { get; set; }
        public Ball Ball { get; set; }
        public SoundManager SoundManager { get; set; }
        public ScoreScreen Score { get; set; }

        public void Update(GameTime gameTime) {
            Ball.Update(gameTime, this);
            PlayerPaddle.Update(gameTime, this);
            ComputerPaddle.Update(gameTime, this);
            ComputerPaddle.UpdateBallPosition(Ball.Position, Ball.Direction);
            Score.Update(ComputerPaddle.Score.ToString(), PlayerPaddle.Score.ToString());
        }

        public void Draw(SpriteBatch spriteBatch) {
            Score.Draw(spriteBatch);
            PlayerPaddle.Draw(spriteBatch);
            ComputerPaddle.Draw(spriteBatch);
            Ball.Draw(spriteBatch);
        }

        public void Dispose()
        {
            Ball.Dispose();
            ComputerPaddle.Dispose();
            PlayerPaddle.Dispose();
        }
    }
}
