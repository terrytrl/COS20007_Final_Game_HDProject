using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class Asteroid : PhysicsObject
    {


        Random _rnd = new Random();

        private PhysicsManager _particleManager;
        private AsteroidParticle _asteroidParticle;

        private bool _asteroidMinned;
        private bool _fireControl;

        private Point2D _location;

        public bool AsteroidMinned { get { return _asteroidMinned; } set { value = _asteroidMinned; } }

        public Asteroid(Point2D startingPoint, Point2D velocity) : base(startingPoint, velocity)
        {
            Img = BitmapManager.Asteroid;

            _location = Location;
        }
        public Asteroid()
        { }

        public override void Update()
        {
            Point2D newLocation = Location;
            if (Location.X == -500)
            {
                newLocation.X = 1800;
                newLocation.Y = _rnd.Next(0, 750);
            }

            Location = newLocation;
            base.Update();
        }
    }
}
