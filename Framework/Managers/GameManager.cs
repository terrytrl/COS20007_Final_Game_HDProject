using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using HDProject.Managers;
using HDProject.Scenes.Space_Scene;
using SplashKitSDK;

namespace HDProject
{
    public class GameManager
    {
        private GameState _currentState;
        private SpaceState _spaceState;
        private AsteroidState _asteroidState;

        private static GameManager _instance;
        /// <summary>
        /// A reference to the singlton factory. (Only one can be exist).
        /// </summary>
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }
        
        public void SwitchToSpace()
        {
            _currentState = _spaceState;
        }
        public void SwitchToAsteroid()
        {
            _currentState = _asteroidState;
        }


        public GameManager()
        {
            _asteroidState = new AsteroidState();
            _spaceState = new SpaceState();
            SwitchToSpace();
        }

        public void Update()
        {
            DebugKeys();
            _currentState.Update();
            //Use the stuff bellow to keeop both states running. 
            //_asteroidState.Update();
            //_spaceState.Update();
        }

        public void Render()
        {
            _currentState.Render();
        }

        public void DebugKeys()
        {
            if (SplashKit.KeyDown(KeyCode.ZKey))
            {
                SwitchToSpace();
            }
            if (SplashKit.KeyDown(KeyCode.XKey))
            {
                SwitchToAsteroid();
            }
        }
    }
}
