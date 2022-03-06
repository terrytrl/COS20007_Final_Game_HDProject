using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class CapitalistEnemy : PhysicsObject
    {
       
        private PhysicsObject _target;

        private bool _isHit;
        public bool IsHit { get { return _isHit; } set { _isHit = value; } }
        /// <summary>
        /// The target to drift trowards.
        /// </summary>
        public PhysicsObject Target { get { return _target; } set { _target = value; } }


        public CapitalistEnemy(Point2D location, Point2D velocity) : base(location, velocity)
        {
            Img = BitmapManager.CapitalistEnemy;
        }

        public override void Update()
        {
            base.Update();

            Point2D position = Location;

            if (Target != null)
            {
                DriftToTarget(position);
            }
            ProcessDeathSequence(position);
            position.Y++;
        }

        public void ProcessDeathSequence(Point2D p)
        {
            if (IsHit == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    p.X--;
                }
            }
        }

        public void DriftToTarget(Point2D p)
        {
            if (p.X < Target.Location.X)
            {
                p.X++;
            }
            if (p.X > Target.Location.X)
            {
                p.X--;
            }
        }
    }
}
