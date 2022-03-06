using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class BitmapManager
    {
        Bitmap _starBitmap = SplashKit.LoadBitmap("star", "C:/Users/Terry/Desktop/HDProject/Resources/images/Star.png");
        
        Bitmap _asteroidParticle = SplashKit.LoadBitmap("asteroidparticle", "C:/Users/Terry/Desktop/HDProject/Resources/images/AsteroidParticle.png");
        
        Bitmap _warpParticle = SplashKit.LoadBitmap("warpParticle", "C:/Users/Terry/Desktop/HDProject/Resources/images/WarpParticle.png");

        Bitmap _laserHit = SplashKit.LoadBitmap("laserHit", "C:/Users/Terry/Desktop/HDProject/Resources/images/LaserHit.png");

        Bitmap _playerShip1 = SplashKit.LoadBitmap("playerShip1_Right", "C:/Users/Terry/Desktop/HDProject/Resources/images/PlayerShip1_Right.png");

        Bitmap _asteroid = SplashKit.LoadBitmap("Asteroid", "C:/Users/Terry/Desktop/HDProject/Resources/images/Asteroid1.png");

        Bitmap _projectileImg = SplashKit.LoadBitmap("Projectile", "C:/Users/Terry/Desktop/HDProject/Resources/images/Projectile_Player.png");

        Bitmap _startingPlanet = SplashKit.LoadBitmap("startingPlanet", "C:/Users/Terry/Desktop/HDProject/Resources/images/StartingPlanet.png");

        Bitmap _paperEnemy = SplashKit.LoadBitmap("paperEnemy", "C:/Users/Terry/Desktop/HDProject/Resources/images/enemies/PaperEnemy.png");
        
        Bitmap _capitalistEnemy = SplashKit.LoadBitmap("capitalistEnemy", "C:/Users/Terry/Desktop/HDProject/Resources/images/enemies/CapitalistEnemy.png");
        
        Bitmap _destroyedParticles = SplashKit.LoadBitmap("destroyedParticles", "C:/Users/Terry/Desktop/HDProject/Resources/images/DestroyedParticle.png");
        
        Bitmap _pressEtoLand = SplashKit.LoadBitmap("pressEtoLand", "C:/Users/Terry/Desktop/HDProject/Resources/images/pressEToLand.png");
        
        Bitmap _robotPlayer = SplashKit.LoadBitmap("RobotPlayer", "C:/Users/Terry/Desktop/HDProject/Resources/images/RobotPlayer.png");
        
        Bitmap _playerShipLanded = SplashKit.LoadBitmap("PlayerShipLanded", "C:/Users/Terry/Desktop/HDProject/Resources/images/PlayerShipLanded.png");


        private static BitmapManager _instance;

        /// <summary>
        /// Singlton pattern
        /// </summary>
        //TODO: Look up singlton pattern. why is it bad?
        //TODO: Google "collission checking observer pattern" add collissions to physics manager.
        //TODO: collaboration. Be selective with relationships.

        //TODO: look at how to apply different patters.
        //TODO: 
        private static BitmapManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BitmapManager();
                }
                return _instance;
            }
        }

        public static Bitmap StarBitmap {get { return Instance._starBitmap; } }
        public static Bitmap AsteroidParticleBitmap { get { return Instance._asteroidParticle; } }
        public static Bitmap WarpParticle { get { return Instance._warpParticle; } }
        public static Bitmap LaserHit { get { return Instance._laserHit; } }
        public static Bitmap PlayerShip1 {get { return Instance._playerShip1; } }
        public static Bitmap Asteroid {get { return Instance._asteroid; } }
        public static Bitmap ProjectileImg { get { return Instance._projectileImg; } }
        public static Bitmap StartingPlanet { get { return Instance._startingPlanet; } }
        public static Bitmap PaperEnemy { get { return Instance._paperEnemy; } }
        public static Bitmap CapitalistEnemy { get { return Instance._capitalistEnemy; } }
        public static Bitmap DestroyedParticles { get { return Instance._destroyedParticles; } }
        public static Bitmap PressEtoLand { get { return Instance._pressEtoLand; } }
        public static Bitmap RobotPlayer { get { return Instance._robotPlayer; } }
        
        public static Bitmap PlayerShipLanded { get { return Instance._playerShipLanded; } }
    }
}
