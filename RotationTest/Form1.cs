using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RotationTest
{
    public partial class Form1 : Form
    {
        Size _size;
        int _posX, _posY;
        float _angle;
        Pen _pen;

        public Form1()
        {
            InitializeComponent();
            _pen = new Pen(Color.Red);
            _size = new Size(50, 50);

            _posX = 0;
            sliderPosX.Maximum = this.ClientSize.Width;
            sliderPosX.Value = 0;

            _posY = 0;
            sliderPosY.Maximum = this.ClientSize.Height;
            sliderPosY.Value = 0;

            _angle = 0;
            sliderAngle.Maximum = 628;
            sliderAngle.Value = 0;

            UpdateLabels();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            // get modified x,y values
            PointF vec = new PointF(_posX, _posY);
            Point vec2 = vec.Rotate(-_angle).ToPoint();

            Graphics graphics = e.Graphics;
            graphics.RotateTransform(_angle * (float)(180.0 / Math.PI));
            graphics.TranslateTransform(vec2.X, vec2.Y);
            graphics.DrawRectangle(_pen, -_size.Width / 2, -_size.Height / 2, _size.Width, _size.Height);
            graphics.ResetTransform();

            // draw center of object
            graphics.DrawEllipse(_pen, _posX - 3, _posY - 3, 6, 6);
        }

        private void sliderPosX_ValueChanged(object sender, EventArgs e)
        {
            _posX = sliderPosX.Value;
            UpdateLabels();
            Invalidate();
        }

        private void sliderPosY_ValueChanged(object sender, EventArgs e)
        {
            _posY = sliderPosY.Value;
            UpdateLabels();
            Invalidate();
        }

        private void sliderAngle_ValueChanged(object sender, EventArgs e)
        {
            _angle = (float)sliderAngle.Value / 100f;
            UpdateLabels();
            Invalidate();
        }

        private void UpdateLabels()
        {
            lblPosX.Text = _posX.ToString();
            lblPosY.Text = _posY.ToString();
            lblAngle.Text = String.Format("{0:0.#}", _angle);
        }
    }

    public static class ExtensionMethods
    {
        public static PointF Rotate(this PointF inputPoint, float angle)
        {
            if (Math.Abs(angle) < 0.001f) return inputPoint;
            float oldAngle = inputPoint.Angle();
            float h = inputPoint.Magnitude();
            float newAngle = oldAngle + angle;
            float newx = h * (float)Math.Cos((double)newAngle);
            float newy = h * (float)Math.Sin((double)newAngle);
            return new PointF(newx, newy);
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

    }
}
