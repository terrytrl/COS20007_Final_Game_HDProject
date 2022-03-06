using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using HDProject.Managers;
using SplashKitSDK;

namespace HDProject
{
    public class EnemyPaperShip : PhysicsObject
    {
        private PhysicsObject _target;

        private bool _isHit;

        /// <summary>
        /// The target to drift trowards.
        /// </summary>
        public PhysicsObject Target { get { return _target; } set { _target = value; } }



        public bool IsHit { get { return _isHit; } set { _isHit = value; } }


        public EnemyPaperShip(Point2D location, Point2D velocity) : base(location, velocity)
        {
            Img = BitmapManager.PaperEnemy;
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
            position.X--;
        }

        public void ProcessDeathSequence(Point2D p)
        {
            if (IsHit == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    p.Y++;
                }
            }
        }

        public void DriftToTarget(Point2D p)
        {
            if (p.Y < Target.Location.Y)
            {
                p.Y++;
            }
            if (p.Y > Target.Location.Y)
            {
                p.Y--;
            }
        }



    }
}
