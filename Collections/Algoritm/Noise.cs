using System;

namespace Rc.Framework.Collections.Algoritm
{
    public class AlgNoise
    {
        public static float Noise(Int64 x, Int64 y)
        {
            var n = x + y * 57;
            n = (n << 13) ^ n;
            return (1 - ((n * (n * n * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824);
        }
        public static float Noise(float x)
        {
            x = ((Int32)x << 13) ^ (Int32)x;
            return (1.0F - (((Int32)x * ((Int32)x * (Int32)x * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0F);
        }
        public static float  SmoothNoise(Int64 x, Int64 y)
        {
            var corners = (float)(Noise(x - 1, y - 1) + Noise(x + 1, y - 1) + Noise(x - 1, y + 1) + Noise(x + 1, y + 1)) / (Int64)16.0F;
            var sides = (Noise(x - 1, y) + Noise(x + 1, y) + Noise(x, y - 1) + Noise(x, y + 1)) / 8.0F;
            var center = Noise(x, y) / 4.0F;
            return corners + sides + center;
        }
        public static float SmoothNoise1D(float x)
        {
            return Noise(x) / 2 + Noise(x - 1) / 4 + Noise(x + 1) / 4;
        }
    }
}
