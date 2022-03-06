using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class StarManager
    {
        Random rnd = new Random();


        private List<Star> _listOfStars = new List<Star>();

        private bool _movingForward = false;
        private int _starVSshipSpeed = 0;

        private PlayerShip _referenceObj = null;
        public int StarVSshipSpeed { get { return _starVSshipSpeed; } set { value = _starVSshipSpeed; } }

        /// <summary>
        /// Creates a star manager with no reference point
        /// (Stars will move at a rate regardless of player movement.)
        /// </summary>
        public StarManager()
        {

        }
        /// <summary>
        ///  Creates a star manager with a reference point to influence velocity of star.
        /// </summary>
        /// <param name="referenceShip">PlayerShip</param>
        public StarManager(PlayerShip referenceShip)
        {
            _referenceObj = referenceShip;
        }

        public void Initialize()
        {
            for (int i = 0; i < 100; i++)
            {
                GenerateStar();
            }
        }

        public void Update()
        {
            UpdateStars();
            if (_referenceObj != null)
            {
                Acceleration(_referenceObj.IsMoving);
            }
            //CullStars();
        }


        private void UpdateStars()
        {
            foreach (Star s in _listOfStars)
            {
                s.Update();
            }
        }

        //TODO: remove stars when they are off the screen
        public void CullStars()
        {
            foreach (Star s in _listOfStars)
            {
                if (s.Location.X < 100)
                {
                    _listOfStars.RemoveAt(0);
                }
                //TODO: do the same for Y.
            }
        }

        public void ProcessInput()
        {
            if (SplashKit.KeyDown(KeyCode.SpaceKey))
            {
                GenerateStar();
            }
        }

        public void Render()
        {
            foreach (Star s in _listOfStars)
            {
                s.Render();
            }
        }

        public void GenerateStar()
        {
            Point2D starVelocity = new Point2D();
            Point2D startPosition = new Point2D();
            startPosition.X = SplashKit.ScreenWidth();
            startPosition.Y = rnd.Next(0, SplashKit.ScreenHeight()); 

            if (_movingForward == true)
            {
                starVelocity.X = (rnd.NextDouble() * 10 - 5);
            }
            else {
                starVelocity.X = (rnd.NextDouble() * 10);
            }
            _listOfStars.Add(new Star(startPosition, starVelocity));
        }

        public void GenerateAsteroidStars()
        {
            Point2D starVelocity = new Point2D();
            Point2D startPosition = new Point2D();
            startPosition.X = SplashKit.ScreenWidth();
            startPosition.Y = rnd.Next(0, SplashKit.ScreenHeight());

            starVelocity.X = -2;
            _listOfStars.Add(new Star(startPosition, starVelocity));
        }

        public void Acceleration(bool playermovingforward)
        {
            if (playermovingforward == true)
            {
                _movingForward = true;
            }else { _movingForward = false; }
            return;
        }
        public void GenerateStars(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateStar();
            }
        }
    }
}
