using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    public abstract class Object2D : IDrawable
    {
        // NOTE:
        // The location is the CENTER of the object! (not the top-left)
        // This is to make rotation easier
        
        // status variables
        public bool doDraw;
        public bool doMove;
        public bool doRemoveFromGame;
        public bool doDrawBoundingBox;

        // position/velocity variables
        public PointF location;
        public PointF velocity; // velocity is in pixels per second
        public PointF acceleration;
        public Size size;
        public Pen pen;
        public float angle;
        public float angleVelocity; // angleVelocity is radians per second
        public float angleAcceleration;

        // Keeps track of time for this object
        protected int tick;

        public Rectangle Rectangle { get { return new Rectangle(Left, Top, Width, Height); } }

        public int Width
        {
            get { return size.Width; }
            set { size.Width = value; }
        }
        public int Height
        {
            get { return size.Height; }
            set { size.Height = value; }
        }
        public int Top 
        { 
            get 
            { return (int)(location.Y - ((float)this.size.Height / 2f)); }
            set 
            { location.Y = value + (int)((float)this.size.Height / 2f); }
        }
        public int Bottom
        {
            get
            { return (int)(location.Y + ((float)this.size.Height / 2f)); }
            set
            { location.Y = value - (int)((float)this.size.Height / 2f); }
        }
        public int Left
        {
            get
            { return (int)(location.X - ((float)this.size.Width / 2f)); }
            set
            { location.X = value + (int)((float)this.size.Width / 2f); }
        }
        public int Right
        {
            get
            { return (int)(location.X + ((float)this.size.Width / 2f)); }
            set
            { location.X = value - (int)((float)this.size.Width / 2f); }
        }
       

        public Object2D(int width, int height, int posX, int posY)
            : this(new Size(width, height), new PointF(posX, posY)) { }

        public Object2D(Size size, PointF location)
        {
            this.doMove = true;
            this.doDraw = true;
            this.doRemoveFromGame = false;
            this.doDrawBoundingBox = false;

            this.tick = 0;
            this.size = size;
            this.location = location;
            this.pen = new Pen(Color.Red);
            this.angle = 0;
            this.angleVelocity = 0;
            this.angleAcceleration = 0;
            this.velocity = new PointF(0, 0);
            this.acceleration = new PointF(0, 0);
        }

        public void Move()
        {
            this.tick++;

            if (this.doMove)
            {
                // velocity is in pixels per second
                // angleVelocity is radians per second

                this.location.X += this.velocity.X;
                this.location.Y += this.velocity.Y;

                this.velocity.X += this.acceleration.X;
                this.velocity.Y += this.acceleration.Y;

                this.angle += this.angleVelocity;
                this.angleVelocity += this.angleAcceleration;
                this.angle %= (float)(2.0 * Math.PI);
            }

            UpdateObject();
        }



        // UpdateObject() is called everytime Move() is called
        protected abstract void UpdateObject();

        // interp is used so the draw location can be estimated for smoother animations
        public void Draw(Graphics graphics, float interp)
        {
            if (this.doDraw)
            {
                // When we draw this baby, we need to make sure that the position is absolute
                // and not relative to rotation angle...
                float x, y, agl;
                GetRotatedDrawLocation(interp, out x, out y, out agl);

                graphics.RotateTransform(agl * (float)(180.0 / Math.PI)); // why would they use degrees? lol
                graphics.TranslateTransform(x, y);

                DrawObject(graphics);
                if (this.doDrawBoundingBox)
                    graphics.DrawRectangle(this.pen, -this.Width / 2, -this.Height / 2, this.Width, this.Height);

                graphics.ResetTransform();
            }
        }

        // Override this method in subclasses to draw whatever you want
        // Draw it centered at the origin! The transformations (position + rotation) have already been done.
        protected abstract void DrawObject(Graphics graphics);

        protected void GetRotatedDrawLocation(float interp, out float x, out float y, out float angle)
        {
            angle = GetDrawAngle(interp);
            float abs_x = GetDrawLocationX(interp);
            float abs_y = GetDrawLocationY(interp);

            // Need to rotate points
            PointF vec = new PointF(abs_x, abs_y);
            vec = vec.Rotate(-angle);
            x = vec.X;
            y = vec.Y;
        }

        protected float GetDrawLocationX(float interp)
        {
            // possibly need to account for acceleration...
            return (this.location.X + this.velocity.X * interp);
        }

        protected float GetDrawLocationY(float interp)
        {
            // possibly need to account for acceleration...
            return (this.location.Y + this.velocity.Y * interp);
        }

        protected float GetDrawAngle(float interp)
        {
            // possibly need to account for acceleration...
            return (this.angle + this.angleVelocity * interp);
        }

    }
}
