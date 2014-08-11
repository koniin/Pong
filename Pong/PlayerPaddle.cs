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

        public PlayerPaddle(Texture2D texture2D, Vector2 position) : base(texture2D, position) { }
    }
}
