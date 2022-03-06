using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class PlayerCharector : PhysicsObject
    {

        private Point2D _newLocation;
        private Point2D _velocity;

        private int _movementDirection;
        private bool _canTakeOff = false;
        public int MovementDirection { get { return _movementDirection; } set { _movementDirection = value; } }
        
        public bool CanTakeOff { get { return _canTakeOff; } set { _canTakeOff = value; } }
        public PlayerCharector(Point2D robotPosition) : base(robotPosition, new Point2D())
        {
            Img = BitmapManager.RobotPlayer;
        }

        public override void Render()
        {
            base.Render();
            Movement();
            if (SplashKit.MouseDown(MouseButton.LeftButton))
            {
                ShootLaser();
            }
        }

        public override void Update()
        {
            base.Update();
        }

        private void Movement()
        {
            Point2D newLocation = Location;
            Point2D newVelocity = Velocity;

            if (SplashKit.KeyDown(KeyCode.DKey))
            {
                newLocation.X += 2;
                _movementDirection = 1;
            }
            if (SplashKit.KeyDown(KeyCode.AKey))
            {
                newLocation.X -= 2;
                _movementDirection = -1;
            }
            else
            {
                _movementDirection = 0;
            }
            //newVelocity.X *= 0.98;
            //newVelocity.Y = 0.98;
            Velocity = newVelocity;
            Location = newLocation;
        }


        private void ShootLaser()
        {
            Point2D LaserHitPoint = SplashKit.MousePosition();
            Line MiningLaser = SplashKit.LineFrom(Location.X + 25, Location.Y, LaserHitPoint.X, LaserHitPoint.Y);
            Line MiningLaser2 = SplashKit.LineFrom(Location.X + 25, Location.Y, LaserHitPoint.X, LaserHitPoint.Y);

            SplashKit.DrawLine(Color.LimeGreen, MiningLaser);
            SplashKit.DrawLine(Color.LimeGreen, MiningLaser2);
        }

    }
}
