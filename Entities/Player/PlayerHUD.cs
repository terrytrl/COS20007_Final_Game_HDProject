using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class PlayerHUD
    {
        private Point2D _throttlePosition;
        private Point2D _directionIndicator;
        private Point2D _hitIndicatorLocation;

        private double _fuelGuageLocationX = 235;
        private double _fuelGuageLocationY = 773;

        public PlayerShip ShipData { get; set; }

        private Point2D _ammoGuageLocation;

        private int _throttleVelocity = 50;

        Bitmap _backgroundPlate = SplashKit.LoadBitmap("starshipUI", "C:/Users/Terry/Desktop/HDProject/Resources/images/StarshipUI/StarshipUI.png");
        Bitmap _throttleHandle = SplashKit.LoadBitmap("StarshipUI_Throttle", "C:/Users/Terry/Desktop/HDProject/Resources/images/StarshipUI/StarshipUI_Throttle.png");

        Bitmap directionIndicator = SplashKit.LoadBitmap("Direction_Light", "C:/Users/Terry/Desktop/HDProject/Resources/images/StarshipUI/Direction_Light.png");
        Bitmap _fuelGuage = SplashKit.LoadBitmap("fuelGuage", "C:/Users/Terry/Desktop/HDProject/Resources/images/StarshipUI/StarshipUI_Fuel.png");
        Bitmap _ammoGuage = SplashKit.LoadBitmap("ammoGuage", "C:/Users/Terry/Desktop/HDProject/Resources/images/StarshipUI/StarshipUI_Fuel.png");
        Bitmap _hitIndicator = SplashKit.LoadBitmap("hitIndicator", "C:/Users/Terry/Desktop/HDProject/Resources/images/StarshipUI/StarshipUI_HitMarker.png");

        Bitmap _background1 = new Bitmap("background1", "C:/Users/Terry/Desktop/HDProject/Resources/images/Backgrounds/Backgroud1");

        public PlayerHUD(PlayerShip ship)
        {
            ShipData = ship;
        }

        public void Render()
        {
            RenderShipUI();
            RenderLandUI();
        }

        public void RenderShipUI()
        {
            _backgroundPlate.Draw(0, 750);

            directionIndicator.Draw(_directionIndicator.X, _directionIndicator.Y);

            _throttleHandle.Draw(_throttlePosition.X, _throttlePosition.Y);

            _hitIndicator.Draw(_hitIndicatorLocation.X, _hitIndicatorLocation.Y);

            _fuelGuage.Draw(_fuelGuageLocationX, _fuelGuageLocationY);

            _ammoGuage.Draw(_ammoGuageLocation.X, _ammoGuageLocation.Y);
        }

        public void Update()
        {
            _throttlePosition.X = 260;
            _throttlePosition.Y = 780;

            _directionIndicator.X = 470;
            _directionIndicator.Y = 817;

            _hitIndicatorLocation.X = -100;
            _hitIndicatorLocation.X = -100;

            bool canMove = ShipData.CanMove;

            if (SplashKit.KeyDown(KeyCode.DKey) && canMove == true)
            {
                _throttlePosition.Y -= _throttleVelocity;
                _directionIndicator.X = 470;
                _directionIndicator.Y = 791;
                if (ShipData.PlayerFuel > 1)
                {
                    _fuelGuageLocationX--;
                }
            }
            if (SplashKit.KeyDown(KeyCode.AKey) && canMove == true)
            {
                _throttlePosition.Y += _throttleVelocity;
                _directionIndicator.X = 470;
                _directionIndicator.Y = 841;
                if (ShipData.PlayerFuel > 1)
                {
                    _fuelGuageLocationX--;
                }
            }
            if (SplashKit.KeyDown(KeyCode.WKey) && canMove == true)
            {
                _directionIndicator.X = 445;
                _directionIndicator.Y = 816;
                if (ShipData.PlayerFuel > 1)
                {
                    _fuelGuageLocationX--;
                }
            }
            if (SplashKit.KeyDown(KeyCode.SKey) && canMove == true)
            {
                _directionIndicator.X = 496;
                _directionIndicator.Y = 816;
                if (ShipData.PlayerFuel > 1)
                {
                    _fuelGuageLocationX--;
                }
            }

            if (SplashKit.KeyReleased(KeyCode.WKey) || SplashKit.KeyReleased(KeyCode.AKey)
                || SplashKit.KeyReleased(KeyCode.SKey) || SplashKit.KeyReleased(KeyCode.DKey) && canMove == true)
            {
                _directionIndicator.X = 470;
                _directionIndicator.Y = 817;
            }

            //TODO: fix is minning in player
            if (ShipData.IsMinning == true)
            {
                _hitIndicatorLocation.X = 644;
                _hitIndicatorLocation.Y = 805;
                if (ShipData.PlayerFuel < 213)
                {
                    _fuelGuageLocationX++;
                    ShipData.PlayerFuel++;
                }
            }

            //TODO: clean up ammo count with loop . each shot X = -52.5
            _ammoGuageLocation.Y = 842;
            if (ShipData.AmmoCount == 5)
            {
                _ammoGuageLocation.X = 1190;
            }
            if (ShipData.AmmoCount == 4)
            { _ammoGuageLocation.X = 1148; }
            if (ShipData.AmmoCount == 3)
            { _ammoGuageLocation.X = 1106; }
            if (ShipData.AmmoCount == 2)
            { _ammoGuageLocation.X = 1064; }
            if (ShipData.AmmoCount == 1)
            { _ammoGuageLocation.X = 1022; }
            if (ShipData.AmmoCount == 0)
            { _ammoGuageLocation.X = 980; }
        }

        public void RenderLandUI()
        {

            if (ShipData.CanLand == true)
            {
                Point2D location;
                location.X = ShipData.Location.X + 50;
                location.Y = ShipData.Location.Y - 50;
                BitmapManager.PressEtoLand.Draw(location.X, location.Y);
            }
        }
    }
}

