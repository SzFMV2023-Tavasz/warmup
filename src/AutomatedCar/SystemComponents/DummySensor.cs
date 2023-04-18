namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using Avalonia;

    /// <summary>
    /// Dummy sensor implementation.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="virtualFunctionBus">The virtual function bus component of our system.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        /// <summary>
        /// Method for calculating the distance between the currently controlled car and the dummy object (circle).
        /// </summary>
        public override void Process()
        {
            var circle = (Circle)World.Instance.WorldObjects.Where(worldObject => worldObject is Circle).First();
            var car = World.Instance.ControlledCar;

            (int distanceX, int distanceY) = GetDistances(car, circle);

            this.dummyPacket.DistanceX = distanceX;
            this.dummyPacket.DistanceY = distanceY;
        }

        private static (int distanceX, int distanceY) GetDistances(AutomatedCar car, Circle circle)
        {
            var carPointsRotated = RotatePoints(car);
            var circlePointsRotated = RotatePoints(circle);

            double carLeft = car.X + carPointsRotated.x.Min();
            double circleRight = circle.X + circlePointsRotated.x.Max();

            double distanceX = 0;
            if (carLeft > circleRight)
            {
                distanceX = carLeft - circleRight;
            }
            else
            {
                double carRight = car.X + carPointsRotated.x.Max();
                double circleLeft = circle.X + circlePointsRotated.x.Min();
                if (circleLeft > carRight)
                {
                    distanceX = circleLeft - carRight;
                }
            }

            double carTop = car.Y + carPointsRotated.y.Min();
            double circleBottom = circle.Y + circlePointsRotated.y.Max();

            double distanceY = 0;
            if (carTop > circleBottom)
            {
                distanceY = carTop - circleBottom;
            }
            else
            {
                double carBottom = car.Y + carPointsRotated.y.Max();
                double circleTop = circle.Y + circlePointsRotated.y.Min();
                if (circleTop > carBottom)
                {
                    distanceY = circleTop - carBottom;
                }
            }

            return ((int)Math.Round(distanceX), (int)Math.Round(distanceY));
        }

        /// <summary>
        /// The function takes the points of the polys of the WorldObject parameter and calculates their distances from the RotationPoint and their respective angles;
        /// from these and the Rotation property of the WorldObject, the function calculates the rotation corrected points RELATIVE to the RotationPoint
        /// AND inverts the resulting Y coordinates so it correlates with our coordinate system where the Y axis increases towards the bottom side.
        /// In practice, if you want to get the true position of a point of an object's geometry,
        /// you have to add these values of the point to the x,y coordinates (which actually indicate the absolute position of the RotationPoint) of the object.
        /// </summary>
        /// <param name="worldObject">The WorldObject to be transformed.</param>
        /// <returns>Returns respective lists of X and Y coordinates, that indicate their position relative to the RotationPoint of the WorldObject.</returns>
        private static (List<double> x, List<double> y) RotatePoints(WorldObject worldObject)
        {
            (List<double> x, List<double> y) points = new ();
            points.x = new List<double>();
            points.y = new List<double>();
            Point rotationPoint = new Avalonia.Point(worldObject.RotationPoint.X, worldObject.RotationPoint.Y);

            foreach (var geometry in worldObject.Geometries)
            {
                foreach (var point in geometry.Points)
                {
                    double distance = GetEuclidianDistance(point, rotationPoint);
                    double phi = GetAngle(point, rotationPoint) + Deg2Rad(-worldObject.Rotation);
                    points.x.Add(Math.Cos(phi) * distance);
                    points.y.Add(-Math.Sin(phi) * distance);
                }
            }

            return points;
        }

        private static double GetEuclidianDistance(Point point, Point rotationPoint) => Math.Sqrt(Math.Pow(point.X - rotationPoint.X, 2) + Math.Pow(point.Y - rotationPoint.Y, 2));

        private static double Deg2Rad(double degree) => (Math.PI / 180) * degree;

        private static double GetAngle(Point point, Point rotationPoint) => Math.Atan2(rotationPoint.Y - point.Y, point.X - rotationPoint.X);
    }
}
