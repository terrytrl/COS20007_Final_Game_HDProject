using System;
using System.Collections.Generic;
using System.Text;
using HDProject.Managers;

using SplashKitSDK;

namespace HDProject.Scenes.Space_Scene
{
    public class SpaceState : GameState
    {
        PlayerShip _playerShip1;
        StarManager _backgroundStars;

        StarManager _midgroundStars;
        private Point2D _playerStartPosition;

        private Point2D _fuelGuageLocation;
        PlayerHUD _starshipUI;
        StartingPlanet _startingPlanet;
        CollissionManager _collissionMgr;

        PhysicsManager _physicsMgr;

        BackgroundManager _backgroundManager;

        public PhysicsManager PhysicsManager { get { return _physicsMgr; } }
        public CollissionManager CollissionMgr { get { return _collissionMgr; } set { _collissionMgr = value; } }
        public PlayerShip PlayerShip1 { get { return _playerShip1; } set { _playerShip1 = value; } }
        public StartingPlanet StartingPlanet { get { return _startingPlanet; } set { _startingPlanet = value; } }
       
        private Point2D _startingPlanetStartLocatio;
        
        private int _asteroidDelay = 60;
        private int EnemyDelay = 240;

        public SpaceState()
        {
            _physicsMgr = new PhysicsManager();
            PlayerShip1 = new PlayerShip(_playerStartPosition, _physicsMgr);
            _midgroundStars = new StarManager(PlayerShip1);

            _playerStartPosition.X = 100;
            _playerStartPosition.Y = 375;

            _backgroundStars = new StarManager();

            _startingPlanet = new StartingPlanet(new Point2D(), new Point2D() { X = -4 });

            _fuelGuageLocation.X = 235;
            _fuelGuageLocation.Y = 791;

            _starshipUI = new PlayerHUD(PlayerShip1);

            _backgroundManager = new BackgroundManager(PlayerShip1);
        }


        public override void HandleInput()
        {

        }

        public override void Update()
        {
            SplashKit.ClearScreen(Color.Black);

            _backgroundManager.Update(1);
            _physicsMgr.Update();
            //HACK: temp
            //_collissionMgr.Update();

            StartingPlanet.Update(PlayerShip1.IsMoving);

            PlayerShip1.Update();

            _asteroidDelay--;
            EnemyDelay--;
            if (_asteroidDelay == 0)
            {
                ObjectFactory.Instance.GenerateAsteroid(_physicsMgr);
                _asteroidDelay = 500;
            }
            if (EnemyDelay == 0)
            {
                ObjectFactory.Instance.GeneratePaperEnemy(_physicsMgr);
                EnemyDelay = 240;
            }

            _backgroundStars.GenerateStars(3);
            _midgroundStars.GenerateStars(5);
            _backgroundStars.Update();
            _midgroundStars.Update();
            _starshipUI.Update();
        }

        public override void Render()
        {
            _backgroundManager.Render(1);
            _backgroundStars.Render();
            _midgroundStars.Render();
            StartingPlanet.Render();
            _physicsMgr.Render();
            PlayerShip1.Render();
            _starshipUI.Render();

        }
    }
}
