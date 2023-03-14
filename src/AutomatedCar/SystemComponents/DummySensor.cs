namespace AutomatedCar.SystemComponents
{
    using System.Linq;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    /// <summary>
    /// Implementation of the dummy sensor, which calculate the X and Y distance between the circle WorldObject and the current Car.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        private int circlePosX;
        private int circlePosY;

        private DummyPacket dummyPacket;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="vbf"> The virtual function bus. </param>
        public DummySensor(VirtualFunctionBus vbf)
            : base(vbf)
        {
            this.dummyPacket = new DummyPacket();
            vbf.DummyPacket = this.dummyPacket;
            var circle = World.Instance.WorldObjects.Where(x => nameof(x) == nameof(Circle)).FirstOrDefault();

            this.circlePosX = circle.X;
            this.circlePosY = circle.Y;
        }

        /// <summary>
        /// Calculates the distancce between the circle and the car.
        /// </summary>
        public override void Process()
        {
            var currentCar = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = this.circlePosX - currentCar.X;
            this.dummyPacket.DistanceY = this.circlePosY - currentCar.Y;
        }
    }
}
