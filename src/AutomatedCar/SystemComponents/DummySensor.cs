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

            this.dummyPacket.DistanceX = Math.Abs(circle.X - car.X) - circle.Radius;
            this.dummyPacket.DistanceY = Math.Abs(circle.Y - car.Y) - circle.Radius;
        }
    }
}
