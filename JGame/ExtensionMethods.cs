using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    public static class ExtensionMethods
    {
        public static PointF YCoordinateToPointF(this double y, double length)
        {
            double x = Math.Sqrt((length * length) - (y * y));
            return new PointF((float)x, (float)y);
        }

        public static PointF YCoordinateToPointF(this float y, float length)
        {
            float x = (float)Math.Sqrt((length * length) - (y * y));
            return new PointF(x, y);
        }

        public static PointF AngleToPointF(this double angle, double length)
        {
            return new PointF((float)length * (float)Math.Cos(angle), (float)length * (float)Math.Sin(angle));
        }

        public static PointF AngleToPointF(this float angle, float length)
        {
            return new PointF(length * (float)Math.Cos(angle), length * (float)Math.Sin(angle));
        }

        #region PointF extensions
        public static PointF Rotate(this PointF inputPoint, float angle)
        {
            if (Math.Abs(angle) < 0.0001f) return inputPoint;
            float oldAngle = inputPoint.Angle();
            float h = inputPoint.Magnitude();
            float newAngle = oldAngle + angle;
            float newx = h * (float)Math.Cos((double)newAngle);
            float newy = h * (float)Math.Sin((double)newAngle);
            return new PointF(newx, newy);
        }

        public static float Magnitude(this PointF inputPoint)
        {
            return (float)Math.Sqrt(inputPoint.X * inputPoint.X + inputPoint.Y * inputPoint.Y);
        }

        public static float Angle(this PointF inputPoint)
        {
            return (float)Math.Atan(inputPoint.Y / inputPoint.X);
        }

        public static Point ToPoint(this PointF inputPoint)
        {
            return new Point((int)inputPoint.X, (int)inputPoint.Y);
        }

        public static PointF Add(this PointF inputPoint, PointF point)
        {
            return inputPoint.Add(point.X, point.Y);
        }

        public static PointF Add(this PointF inputPoint, float x, float y)
        {
            return new PointF(inputPoint.X + x, inputPoint.Y + y);
        }

        public static PointF Subtract(this PointF inputPoint, PointF point)
        {
            return inputPoint.Subtract(point.X, point.Y);
        }

        public static PointF Subtract(this PointF inputPoint, float x, float y)
        {
            return new PointF(inputPoint.X - x, inputPoint.Y - y);
        }

        public static PointF SetLength(this PointF inputPoint, float magnitude)
        {
            float angle = inputPoint.Angle();
            return new PointF(magnitude * (float)Math.Cos(angle), magnitude * (float)Math.Sin(angle));
        }
        #endregion

    }
}
