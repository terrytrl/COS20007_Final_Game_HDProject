using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class PlasmaBolt : PhysicsObject
    {

        private bool _projectileCollision = false;
        private bool _fireControl = true;

        
        public bool ProjectileCollision { get { return _projectileCollision; } set { value = _projectileCollision; } }

        public PlasmaBolt(Point2D startingPoint, Point2D velocity) : base(startingPoint, velocity)
        {
            Img = BitmapManager.ProjectileImg;

        }

        public override void Update()
        {
            base.Update();

            

        }
    }
}
