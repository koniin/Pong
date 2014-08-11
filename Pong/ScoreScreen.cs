using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public class ScoreScreen
    {
        private Vector2 positionP1;
        private Vector2 positionP2;
        private SpriteFont font;
        private string p1Score = "0";
        private string p2Score = "0";

        public ScoreScreen(SpriteFont font, Vector2 positionP1, Vector2 positionP2)
        {
            this.font = font;
            this.positionP1 = positionP1;
            this.positionP2 = positionP2;
        }

        public void Update(string p1Score, string p2Score)
        {
            this.p1Score = p1Score;
            this.p2Score = p2Score;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, p1Score, positionP1, Color.White);
            spriteBatch.DrawString(font, p2Score, positionP2, Color.White);
        }
    }
}
