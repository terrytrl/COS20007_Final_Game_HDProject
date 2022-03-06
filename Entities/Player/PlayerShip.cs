using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using SplashKitSDK;

namespace HDProject
{
    public class PlayerShip : PhysicsObject
    {
        StarManager starMgr = new StarManager();
        PhysicsManager _physicsMgr;

        private int _ammoCount = 5;

        private int _playerHealth = 213;

        private double _playerFuel = 213;

        private bool _canLand;

        public bool CanLand { get { return _canLand; } set { _canLand = value; } }

        public int AmmoCount { get { return _ammoCount; } }
        public double PlayerFuel { get { return _playerFuel; } set { _playerFuel = value; } }
        public int PlayerHealth { get { return _playerHealth; } set { _playerHealth = value; } }

        //TODO: update velocity to inherit property, challange get throttle working. 
        private int _velocityMultiplyer = 3;
        private int _velocityY = 6;

        private bool _isMoving = false;
        private bool _canMove = true;
        private bool _isMinning = false;
        private bool _canTakeOff = false;

        public bool IsMoving { get { return _isMoving; } set { _isMoving = value; } }
        public bool CanMove { get { return _canMove; } set { _canMove = value; } }
        public bool IsMinning { get { return _isMinning; } set { _isMinning = value; } }
        public bool CanTakeOff { get { return _canTakeOff; } set { _canTakeOff = value; } }


        private bool _fireMinningLazer = false;

        public PlayerShip(Point2D shipPosition, PhysicsManager physicsManager) : base(shipPosition, new Point2D())
        {
            Img = BitmapManager.PlayerShip1;
            _physicsMgr = physicsManager;
        }

        public override void Render()
        {
            base.Render();
            if (_fireMinningLazer == true)
            {
                RenderMinningLaser();
                BitmapManager.LaserHit.Draw(SplashKit.MouseX(), SplashKit.MouseY());
            }
        }

        public override void Update()
        {
            Point2D newVelocity = Velocity;
            //TODO: fix fuel system
            if (PlayerFuel > 0 && CanMove == true)
            {
                if (SplashKit.KeyDown(KeyCode.LeftShiftKey))
                {
                    _velocityMultiplyer = 2;
                }
                else
                {
                    _velocityMultiplyer = 1;
                }

                if (SplashKit.KeyDown(KeyCode.WKey))
                {
                    newVelocity.Y = -6;
                    _playerFuel--;
                    _isMoving = true;
                }

                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    newVelocity.Y = 6;
                    _playerFuel--;
                    _isMoving = true;
                }

                if (SplashKit.KeyDown(KeyCode.AKey))
                {
                    //Player can not move off the left side of the screen.
                    if (Location.X >= 1)
                    {
                        newVelocity.X = -3 * _velocityMultiplyer;
                        _playerFuel--;
                        _isMoving = true;
                    }
                }
                if (SplashKit.KeyDown(KeyCode.DKey))
                {
                    newVelocity.X = 3 * _velocityMultiplyer;
                    _playerFuel--;
                    _isMoving = true;
                }
                else { _isMoving = false; }
            }

            ShipWrap();
            newVelocity.X *= 0.98;
            newVelocity.Y *= 0.98;
            Velocity = newVelocity;
            base.Update();

            //Laser and projectile interaction

            _fireMinningLazer = SplashKit.MouseDown(MouseButton.LeftButton);
            
            if (SplashKit.KeyReleased(KeyCode.SpaceKey))
            {
                if (_ammoCount > 0)
                {
                    _ammoCount--;
                    ObjectFactory.Instance.GeneratePlasmaBolt(Location, _physicsMgr);
                }
            }
            if (SplashKit.KeyDown(KeyCode.RKey))
            {
                _ammoCount = 5;
            }
        }

        public void ShipWrap()
        {
            Point2D newPos = Location;
            if (Location.X >= 1420)
            {
                newPos.X = -105;
            }
            if (Location.Y <= -105)
            {
                newPos.Y = 832;
            }
            if (Location.Y >= 832)
            {
                newPos.Y = -105;
            }
            Location = newPos;
            WrapAroundParticles();
        }

        private void RenderMinningLaser()
        {
            Point2D LaserHitPoint = SplashKit.MousePosition();
            Line MiningLaser = SplashKit.LineFrom(Location.X + 100, Location.Y + 60, LaserHitPoint.X, LaserHitPoint.Y);
            Line MiningLaser2 = SplashKit.LineFrom(Location.X + 100, Location.Y + 69, LaserHitPoint.X, LaserHitPoint.Y);

            SplashKit.DrawLine(Color.LimeGreen, MiningLaser);
            SplashKit.DrawLine(Color.LimeGreen, MiningLaser2);
        }

        private void WrapAroundParticles()
        {

            Point2D position;
            position.X = Location.X + 60;
            position.Y = Location.Y + 60;

            double dX = 0;
            double dY = 0;

            if (Location.X > 1300)
            {
                dX = -10;
                dY = 8 - 3;
            }
            if (Location.Y < 20)
            {
                dX = 8 - 3;
                dY = 10;
            }
            if (Location.Y > 700)
            {
                dX = 8 - 3;
                dY = -10;
            }
            if (dX != 0 || dY != 0)
            {
                ObjectFactory.Instance.GenerateWarpParticle(Location, _physicsMgr, dX, dY);
            }
        }
    }
}
