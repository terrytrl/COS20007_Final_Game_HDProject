using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class Star : PhysicsObject
    {

        public Star(Point2D position, Point2D velocity) : base(position, velocity)
        {
            Img = BitmapManager.StarBitmap;
        }

        
        public override void Render()
        {
            base.Render();
            //Color c = SplashKit.RandomColor();
            //SplashKit.DrawPixel(c, Location.X, Location.Y-2);
        }

    }
}
