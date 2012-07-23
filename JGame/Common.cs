using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    public enum KeyState
    {
        Up,
        Down
    }

    public enum NPCMovementType
    {
        DontMove,
        Normal,
        SineWaveVertical,
        SineWaveHorizontal,
        ZigZagVertical,
        ZigZagHorizontal,
        FollowObject,
        Waypoints,
        Random
    }

    public static class Common
    {
        public static PointF CreateRandomPointF(float magnitude)
        {
            Random rand = new Random();
            double angle = (rand.NextDouble() * 2.0 * Math.PI);
            double x = magnitude * Math.Cos(angle);
            double y = magnitude * Math.Sin(angle);
            return new PointF((float)x, (float)y);
        }

    }
}
