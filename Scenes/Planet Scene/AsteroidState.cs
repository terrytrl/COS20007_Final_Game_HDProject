using System;
using System.Collections.Generic;
using System.Text;
using HDProject.Managers;
using SplashKitSDK;

namespace HDProject
{
    public class AsteroidState : GameState
    {
        PlayerCharector _playerCharector;
        PlayerShipLanded _playerShipLanded;

        StarManager _asteroidStars;


        private int asteroidEnemyDelay = 240;

        public PlayerShipLanded PlayerShipLanded { get { return _playerShipLanded; } }
        public PlayerCharector PlayerCharector { get { return _playerCharector; } set { _playerCharector = value; } }
        //public PhysicsManager PhysicsManager { get { return _physicsMgr; } }
        //public CollissionManager CollissionMgr { get { return _collissionMgr; } set { _collissionMgr = value; } }
        //public ObjectFactory SpawnMgr { get { return _spawnMgr; } }

        public AsteroidState()
        {
            Point2D _robotStartPosition;
            _robotStartPosition.X = 100;
            _robotStartPosition.Y = 700;
            _playerCharector = new PlayerCharector(_robotStartPosition);

            Point2D _playerLandedPosition;
            _playerLandedPosition.X = 1000;
            _playerLandedPosition.Y = 690;
            _playerShipLanded = new PlayerShipLanded(_playerLandedPosition);

            _asteroidStars = new StarManager();

        }

        public override void HandleInput()
        {
        }

        public override void Update()
        {
            _playerCharector.Update();
            //_physicsMgr.Update();
            //_collissionMgr.Update();

            //_sceneManager.Update();
            //_backgroundManager.Update(11);

            //asteroidEnemyDelay--;
            //if (asteroidEnemyDelay == 0)
            //{
            //    //TODO:
            //    _spawnMgr.GenerateCapitalists();
            //    asteroidEnemyDelay = 240;
            //}

        }

        public override void Render()
        {
            SplashKit.ClearScreen(Color.Black);

            _playerCharector.Render();
            _playerShipLanded.Render();

            //_backgroundStars.Render();

            //_midgroundStars.Render();

            //_backgroundManager.Render(11);

            //asteroidEnemyDelay--;
            //if (asteroidEnemyDelay == 0)
            //{
            //    _spawnMgr.GenerateCapitalists();
            //    asteroidEnemyDelay = 240;
            //}
            //_physicsMgr.Render();

        }
    }
}
