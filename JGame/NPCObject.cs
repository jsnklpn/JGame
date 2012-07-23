using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    public class NPCObject : Sprite2D
    {
        protected int health;
        protected NPCMovementType movement;
        protected Object2D objectToFollow;
        protected Point[] waypoints;
        protected float maxVelocity;
        
        Random rand;

        public float MaxVelocity { get { return this.maxVelocity; } set { this.maxVelocity = value; } }

        // for sine and sawtooth patterns
        int amplitude, wavelength;

        public NPCObject(System.Drawing.Image image, int initialHealth = 100)
            : base(image, System.Drawing.Point.Empty)
        {
            this.rand = new Random();
            this.amplitude = 0;
            this.wavelength = 0;
            this.waypoints = null;
            this.objectToFollow = null;
            this.movement = NPCMovementType.Normal;
            this.health = initialHealth;
            this.maxVelocity = 100f;
        }

        protected override void UpdateObject()
        {
            base.UpdateObject();

            if (this.health <= 0)
                this.doRemoveFromGame = true;

            switch (this.movement)
            {
                case NPCMovementType.Normal:
                    {
                        // Do nothing special
                    }
                    break;
                case NPCMovementType.DontMove:
                    {
                        this.velocity = PointF.Empty;
                        this.acceleration = PointF.Empty;
                    }
                    break;
                case NPCMovementType.FollowObject:
                    {
                        if (this.objectToFollow != null)
                        {
                            // follow object at max velocity

                        }
                    }
                    break;
                case NPCMovementType.Random:
                    {
                        // TODO: Make this pseudo-random instead of true random. We don't the object to shake in place...
                        this.velocity = Common.CreateRandomPointF((float)this.rand.NextDouble() * this.maxVelocity);
                    }
                    break;
                case NPCMovementType.SineWaveHorizontal:
                    {
                        // calculate velocity based on tick
                        this.velocity.Y = this.amplitude * (float)Math.Sin((double)this.tick / (double)this.wavelength);
                        this.velocity.X = this.maxVelocity;
                    }
                    break;
                case NPCMovementType.SineWaveVertical:
                    {
                        // calculate velocity based on tick
                        double m = amplitude * wavelength * Math.Cos(wavelength * this.tick);
                        double angle = Math.Atan(m);
                        PointF vel = angle.AngleToPointF(this.maxVelocity);
                        this.velocity.X = vel.Y;
                        this.velocity.Y = vel.X;
                    }
                    break;
                case NPCMovementType.ZigZagHorizontal:
                    {

                    }
                    break;
                case NPCMovementType.ZigZagVertical:
                    {

                    }
                    break;
                default:
                    {
                        // Normal
                    }
                    break;
            }

        }

        #region Follow types
        public void FollowObject(Object2D obj)
        {
            this.objectToFollow = obj;
            this.movement = NPCMovementType.FollowObject;
        }

        public void DontMove()
        {
            this.movement = NPCMovementType.DontMove;
        }

        public void FollowWaypoints(Point[] waypoints)
        {
            this.waypoints = waypoints;
            this.movement = NPCMovementType.Waypoints;
        }

        public void FollowSineWave(bool vertical, int amplitude, int wavelength)
        {
            this.amplitude = amplitude;
            this.wavelength = wavelength;

            if (vertical)
                this.movement = NPCMovementType.SineWaveVertical;
            else
                this.movement = NPCMovementType.SineWaveHorizontal;
        }

        public void FollowZigZag(bool vertical, int amplitude, int wavelength)
        {
            this.amplitude = amplitude;
            this.wavelength = wavelength;

            if (vertical)
                this.movement = NPCMovementType.ZigZagVertical;
            else
                this.movement = NPCMovementType.ZigZagHorizontal;
        }

        public void FollowRandom()
        {
            this.movement = NPCMovementType.Random;
        }

        public void FollowNormal()
        {
            this.movement = NPCMovementType.Normal;
        }
        #endregion

    }
}
