using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class StartingPlanet : PhysicsObject
    {
        //StartingPlanetLocation and StartingPlanetBitmap used for collision detection using CollisionDetection Class
        
        public StartingPlanet(Point2D startingPosition, Point2D startingVelocity) : base(startingPosition, startingVelocity)
        {
            Img = BitmapManager.StartingPlanet;
            
        }

        public override void Update(bool playerMovingForward)
        {
            if (playerMovingForward || Location.X < 0)
            { 
                base.Update();
            }
        }
    }
}
