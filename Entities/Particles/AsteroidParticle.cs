using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class AsteroidParticle : PhysicsObject
    {
        //TODO: Add a lifetime to particle. 
        public AsteroidParticle(Point2D position, Point2D velocity) : base(position, velocity)
        {
            Img = BitmapManager.AsteroidParticleBitmap;
        }



    }   
}
