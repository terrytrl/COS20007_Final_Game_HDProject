using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class DestroyedParticles : PhysicsObject
    {
        public DestroyedParticles(Point2D position, Point2D velocity) : base(position, velocity)
        {
            Img = BitmapManager.DestroyedParticles;
        }
    }
}
