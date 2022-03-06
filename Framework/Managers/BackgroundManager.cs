using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject.Managers
{
    public class BackgroundManager
    {
        GameManager _currentGame;

        private Point2D _location;

        private PlayerShip _playerShip;

        Bitmap _backgroundMoving1 = SplashKit.LoadBitmap("BackgroudMovingAsteroid1", "C:/Users/Terry/Desktop/HDProject/Resources/images/Backgrounds/BackgroudMoving1.png");
        Bitmap _backgroundAsteroidMoving1 = SplashKit.LoadBitmap("BackgroundAsteroidMoving1", "C:/Users/Terry/Desktop/HDProject/Resources/images/Backgrounds/BackgroudMovingAsteroid1.png");



        public BackgroundManager(PlayerShip playership)
        {
            _playerShip = playership;
        }

        public void Render(int scene)
        {
            switch (scene)
            {
                case 1:
                    //Starting Planet
                    _backgroundMoving1.Draw(_location.X, _location.Y);
                    break;
                case 11:
                    //Asteroid Landed.
                    _location.X = 0;
                    _location.Y = 0;
                    _backgroundAsteroidMoving1.Draw(_location.X, _location.Y);
                    break;
            }
        }

        public void Update(int scene)
        {

            switch (scene)
            {
                case 1:
                    //Starting Planet
                    if (_playerShip.IsMoving || _location.X < 0)
                    {
                        _location.X--;
                    }
                    break;
                case 11:
                    //Asteroid Landed.
    
                    break;
            }
        }
    }
}
