using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public class ComputerPaddle : Paddle
    {
        public int Score { get; set; }

        public ComputerPaddle(Texture2D texture2D, Vector2 position) : base(texture2D, position) { }
    }
}
