using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class CollissionManager
    {
        private bool _playerCollided;

        PlayerShip _playerShip;
        Asteroid _asteroid;

        StartingPlanet _startingPlanet;

        private bool _isColliding;
        private bool _isMinning;

        public bool PlayerCollided { get { return _playerCollided; } set { value = _playerCollided; } }
        public bool IsMinning { get { return _isMinning; } set { value = _isMinning; } }

        private static CollissionManager _instance;

        /// <summary>
        /// A reference to the singlton factory. (Only one can be exist).
        /// </summary>
        public static CollissionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CollissionManager();
                }
                return _instance;
            }
        }

        private CollissionManager()
        {


        }

        //Collission testing.Replace with foreach and cycle through the list of enemies/planets/things.
          

        /// <summary>
        /// Checks the collisions between a given asteroid and a mouse point. 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool MouseAtAsteroid(Asteroid a)
        {
            return SplashKit.BitmapCollision(BitmapManager.Asteroid, a.Location,
                 BitmapManager.LaserHit, SplashKit.MousePosition());
        }

        public bool AsteroidLandingInRange(Asteroid a, PhysicsObject p)
        {
            return SplashKit.BitmapCollision(BitmapManager.PlayerShip1, p.Location, BitmapManager.Asteroid, a.Location);
        }

        //TODO: Imploment when enemy spawn system is finished. 
        public bool PlasmaCollidid(EnemyPaperShip e, PlasmaBolt p)
        {
            return SplashKit.BitmapCollision(BitmapManager.ProjectileImg, p.Location, BitmapManager.PaperEnemy, e.Location);
        }

        //TODO playerShipHit.

        public void ShipHit()
        { }

        //public void StartingPlanetCollision()
        //{
        //    if (SplashKit.BitmapCollision(BitmapManager.StartingPlanet, _currentGame.StartingPlanet.Location, BitmapManager.PlayerShip1, _currentGame.PlayerShip1.Location))
        //    {
        //        _playerCollided = true;
        //    }
        //    else
        //    {
        //        _playerCollided = false;
        //    }
        //}

        //public void GetInShip()
        //{
        //    if (SplashKit.BitmapCollision(BitmapManager.RobotPlayer, _currentGame.PlayerCharector.Location, BitmapManager.PlayerShipLanded, _currentGame.PlayerShipLanded.Location))
        //    {
        //        _currentGame.PlayerCharector.CanTakeOff = true;
        //    }
        //    else { _currentGame.PlayerCharector.CanTakeOff = false; }

        //}


        //TODO: finish this.
        //public void ShootAsteroid()
        //{
        //    if (SplashKit.BitmapCollision(BitmapManager.CapitalistEnemy, _currentGame.SpawnMgr.CapitalistEnemy.Location, BitmapManager.LaserHit, _currentGame.PlayerShipLanded.Location, SplashKit.MousePosition() && (isLasering == true)))
        //    {
        //        Console.WriteLine("pew pew pew");
        //    }
        //}

    }
}