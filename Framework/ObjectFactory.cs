using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class ObjectFactory
    {
        Random _rnd = new Random();

        Asteroid _asteroid;

        EnemyPaperShip _paperEnemyShip;

        CapitalistEnemy _capitalistEnemy;

        private List<Asteroid> _listOfAsteroids = new List<Asteroid>();

        Point2D _asteroidStart = new Point2D();
        Point2D _asteroidVelocity = new Point2D();

        Point2D _plasmaStart = new Point2D();
        Point2D _plasmaVelocity = new Point2D();

        Point2D _plasmaLocation;

        Point2D _paperEnemyShipStartLocation = new Point2D();
        Point2D _paperEnemtVelocity = new Point2D();

        Point2D _capitalistEnemyStartLocation = new Point2D();
        Point2D _capitalistEnemyVelocity = new Point2D();


        public Asteroid Asteroid { get { return _asteroid; } }
        public EnemyPaperShip PaperEnemyShip { get { return _paperEnemyShip; } }

        public CapitalistEnemy CapitalistEnemy { get { return _capitalistEnemy; } }

        private static ObjectFactory _instance;

        /// <summary>
        /// A reference to the singlton factory. (Only one can be exist).
        /// </summary>
        public static ObjectFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ObjectFactory();
                }
                return _instance;
            }
        }

        /// <summary>
        /// This is private because of singlton pattern. You should never construct this! 
        /// </summary>
        private ObjectFactory()
        {

        }

        //TODO: come back to this This is the code thats generating asteroids every frame.
        public Asteroid GenerateAsteroid(PhysicsManager manager)
        {
            
            _asteroidStart.X = 1400;
            _asteroidStart.Y = _rnd.Next(40, 700);

            _asteroidVelocity.X = -1;
            
            Asteroid a = new Asteroid(_asteroidStart, _asteroidVelocity);
            manager.RegisterPhysicsObject(a);
            return a;
        }

        public EnemyPaperShip GeneratePaperEnemy(PhysicsManager manager)
        {
            _paperEnemyShipStartLocation.X = 1400;
            _paperEnemyShipStartLocation.Y = _rnd.Next(0, 750);

            _paperEnemtVelocity.X = -4;
            EnemyPaperShip e = new EnemyPaperShip(_paperEnemyShipStartLocation, _paperEnemtVelocity);
            manager.RegisterPhysicsObject(e);
            return e;
        }

        //Hack: This is the real way a factory should be done. look at return type. 
        public PlasmaBolt GeneratePlasmaBolt(Point2D pt, PhysicsManager manager)
        {
            _plasmaStart.X = pt.X;
            _plasmaStart.Y = pt.Y;
            _plasmaVelocity.X = 10;

            PlasmaBolt plasmaBolt = new PlasmaBolt(_plasmaStart, _plasmaVelocity);
            manager.RegisterPhysicsObject(plasmaBolt);
            return plasmaBolt;
        }

        /// <summary>
        /// Generate an enemy that drifts to a given target.
        /// </summary>
        /// <param name="target"></param>
        public CapitalistEnemy GenerateCapitalists(PhysicsObject target, PhysicsManager manager)
        {
            _capitalistEnemyStartLocation.X = _rnd.Next(100, 1300);
            _capitalistEnemyStartLocation.Y = 10;

            _capitalistEnemyVelocity.Y = 2;

            CapitalistEnemy capitalistEnemy = new CapitalistEnemy(_capitalistEnemyStartLocation, _capitalistEnemyVelocity);
            _capitalistEnemy.Target = target;
            manager.RegisterPhysicsObject(capitalistEnemy);
            return capitalistEnemy;
        }

        /// <summary>
        /// Generate an enimy that doesnt drift top any target.
        /// </summary>
        public CapitalistEnemy GenerateCapitalists(PhysicsManager manager)
        {
           return GenerateCapitalists(null, manager);
        }

        public AsteroidParticle GenerateAsteroidParticle(Point2D location, PhysicsManager manager)
        {
            Point2D projectileVelocity = new Point2D();
            projectileVelocity.X = (_rnd.NextDouble() * 10 - 5);
            projectileVelocity.Y = (_rnd.NextDouble() * 10 - 5);
            AsteroidParticle ap = new AsteroidParticle(location, projectileVelocity);
            manager.RegisterPhysicsObject(ap);
            return ap;
        }

        public WarpParticle GenerateWarpParticle(Point2D location, PhysicsManager manager, double dX, double dY)
        {
            Point2D WarpDirection;
            WarpDirection.X = _rnd.NextDouble() * dX;
            WarpDirection.Y = _rnd.NextDouble() * dY;
            WarpParticle wp = new WarpParticle(location, WarpDirection);
            manager.RegisterPhysicsObject(wp);
            return wp;
        }
    }
}
