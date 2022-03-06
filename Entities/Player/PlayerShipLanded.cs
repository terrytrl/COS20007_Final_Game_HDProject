using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class PlayerShipLanded : PhysicsObject
    {
        public PlayerShipLanded(Point2D position) : base(position, new Point2D())
        {
            Img = BitmapManager.PlayerShipLanded;
        }
    }
}
