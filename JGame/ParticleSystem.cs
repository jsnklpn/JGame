using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGame
{
    public class ParticleSystem : NPCObject
    {
        protected Particle particle;
        protected int tickDelay;
        protected int particleCount; // max particles
        protected int particleRate; // how many per delay

        protected float fireAngle;
        protected float fireAngleRangle;

        protected int particlesFired;

        public ParticleSystem(IGameStage stage, int posx, int posy,
            Particle particleToEmit, int delay, int count,
            int rate, float angle, float angleRange)
            : base(null)
        {
            this.particlesFired = 0;

            this.location.X = posx;
            this.location.Y = posy;
            this.tickDelay = delay;
            this.particle = particleToEmit;
            this.particleCount = count;
            this.particleRate = rate;
            this.fireAngle = angle;
            this.fireAngleRangle = angleRange;
        }

        protected override void UpdateObject()
        {
            base.UpdateObject();

            if (this.particlesFired >= particleCount)
            {
                this.health = 0; // remove from game
                return;
            }

            if (this.tick % tickDelay == 0)
            {
                // TODO
                // create particle (count: particleRate)
                //Particle p = new Particle(particle.Image, 

            }
            
        }

    }
}
