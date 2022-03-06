using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;


namespace HDProject
{
    public class PhysicsObject
    {
        private Point2D _location;
        private Point2D _velocity;

        private Bitmap _img;

        protected Bitmap Img {get { return _img; } set { _img = value; } }

        public Point2D Location { get { return _location; } set { _location = value; } }
        
        public Point2D Velocity { get { return _velocity; } set { _velocity = value; } }

        public PhysicsObject(Point2D startingPoint, Point2D velocity)
        {
            Location = startingPoint;
            Velocity = velocity;
        }

        public PhysicsObject()
        { }

        public virtual void Render()
        {
            SplashKit.DrawBitmap(Img, Location.X, Location.Y);
        }

        public virtual void Update()
        {
            UpdatePosition();
        }

        public virtual void Update(bool condition)
        {
            
            UpdatePosition();

        }

        public virtual void UpdatePosition()
        {
            Point2D newPosition = new Point2D();
            newPosition.X = Location.X + Velocity.X;
            newPosition.Y = Location.Y + Velocity.Y;
            Location = newPosition;
        }
    }
}
