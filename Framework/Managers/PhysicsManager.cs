using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDProject
{
    public class PhysicsManager : PhysicsObject
    {
        Random rnd = new Random();

        private List<PhysicsObject> _listOfProjectiles = new List<PhysicsObject>();
        public List<PhysicsObject> ListOfObjects { get { return _listOfProjectiles; } }

        private List<Point2D> _listOfLocations = new List<Point2D>();

        public Asteroid Asteroid { get; set; }

        
        public PhysicsManager()
        {

        }

        public override void Render()
        {
            base.Render();
            foreach (PhysicsObject p in _listOfProjectiles)
            {
                p.Render();
            }
        }

        //TODO: memory management, cull method. copy paste updates that need to be culled. 
        //TODO: This is broken :(.

        public override void Update()
        {
            base.Update();
            UpdateProjectiles();

            //CullObjects();

        }

        public void CullObjects()
        {
            List<PhysicsObject> objectsToCull = new List<PhysicsObject>();
            foreach (PhysicsObject _physicsObject in _listOfProjectiles)
            {
                if (_physicsObject.Location.X < 100)
                {

                    objectsToCull.Add(_physicsObject);
                }
            }
            if (objectsToCull.Count > 0)
            {
                if (objectsToCull != null)
                {
                    foreach (PhysicsObject _physicsObject in objectsToCull.ToList())
                    {
                        objectsToCull.Remove(_physicsObject);
                    }
                }
            }
        }

        public void RegisterPhysicsObject(PhysicsObject p)
        {
            _listOfProjectiles.Add(p);
        }

        public void RemovePhysicsObject(PhysicsObject p)
        {
            _listOfProjectiles.Remove(p);
        }

        private void UpdateProjectiles()
        {
            foreach (PhysicsObject p in _listOfProjectiles)
            {
                p.Update();
            }
        }

        public void LimitObjects(int limit)
        {
            if (_listOfProjectiles.Count == limit)
            {
                _listOfProjectiles.RemoveAt(1);
            }
        }


    }
}

