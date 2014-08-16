using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong {
    public static class Calc2D {
        public static Vector2 GetRightPointingAngledPoint(int degrees) {
            double angle = Math.PI * degrees / 180.0;
            double sinAngle = Math.Sin(angle);
            double cosAngle = Math.Cos(angle);

            float xAngle = (float)sinAngle;
            float yAngle = (float)cosAngle;

            return new Vector2(xAngle, yAngle);
        }

        public static Vector2 GetRandomDirection(Random random) {
            double azimuth = random.NextDouble() * 2 * 3.14;
            return new Vector2((float)Math.Cos(azimuth), (float)Math.Sin(azimuth));
        }
    }
}
