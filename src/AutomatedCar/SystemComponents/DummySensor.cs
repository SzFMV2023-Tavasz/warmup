namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

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

            int carLeft = car.X - (int)car.Geometry.Bounds.Center.X + (int)car.Geometry.Bounds.Left;
            int carRight = car.X - (int)car.Geometry.Bounds.Center.X + (int)car.Geometry.Bounds.Right;
            int circleLeft = circle.X - circle.Radius;
            int circleRight = circle.X + circle.Radius;

            int carTop = car.Y - (int)car.Geometry.Bounds.Center.Y + (int)car.Geometry.Bounds.Top;
            int carBottom = car.Y - (int)car.Geometry.Bounds.Center.Y + (int)car.Geometry.Bounds.Bottom;
            int circleTop = circle.Y;
            int circleBottom = circle.Y + (2 * circle.Radius);

            int distanceX = 0;
            if (!(carLeft <= circleRight && circleLeft <= carRight))
            {
                distanceX = (carLeft > circleRight) ? carLeft - circleRight : circleLeft - carRight;
            }

            int distanceY = 0;
            if (!(carTop <= circleBottom && circleTop <= carBottom))
            {
                distanceY = (circleBottom < carTop) ? carTop - circleBottom : circleTop - carBottom;
            }

            this.dummyPacket.DistanceX = distanceX;
            this.dummyPacket.DistanceY = distanceY;
        }

        private static double RotationConverter(double rotation) => -rotation + 90;
    }
}
