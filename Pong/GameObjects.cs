using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public class GameObjects
    {
        public PlayerPaddle PlayerPaddle { get; set; }
        public ComputerPaddle ComputerPaddle { get; set; }
        public Ball Ball { get; set; }
        public SoundManager SoundManager { get; set; }
    }
}
