using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class WarpParticle : PhysicsObject
    {
        public WarpParticle(Point2D position, Point2D velocity) : base(position, velocity)
        {
            Img = BitmapManager.WarpParticle; 
        }

        public override void Update()
        {
            base.Update();


        }
    }
}
