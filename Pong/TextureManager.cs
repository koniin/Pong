using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public static class TextureManager
    {
        private static Texture2D CreateTexture(int width, int height)
        {
            Color[] foregroundColors = new Color[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    foregroundColors[x + y * width] = Color.White;
                }
            }

            Texture2D texture = new Texture2D(GraphicsDevice, width, height, false, SurfaceFormat.Color);
            texture.SetData(foregroundColors);
            return texture;
        }
    }
}
