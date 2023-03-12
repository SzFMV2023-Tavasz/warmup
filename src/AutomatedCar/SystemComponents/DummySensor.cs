namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using AutomatedCar.ViewModels;
    using ReactiveUI;
    using System;

    /// <summary>
    /// DummySensor class, calulates the distance between the circle and the car.
    /// </summary>
    public class DummySensor : SystemComponent
    {

        private int circleX;
        private int circleY;

        private DummyPacket packet;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class and sets the values for the circle since its stationary.
        /// </summary>
        /// <param name="virtualFunctionBus">virtualBus.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.packet = new DummyPacket() { DistanceX = 999, DistanceY = 999 };
            this.virtualFunctionBus.DummyPacket = this.packet;
        }

        /// <summary>
        /// Process method for the DummySensor, calculates the x and y distance between the car and the circle and puts it in the dummypacket.
        /// </summary>
        public override void Process()
        {
            this.circleX = World.Instance.WorldObjects[0].X;
            this.circleY = World.Instance.WorldObjects[0].Y;

            int carX = World.Instance.ControlledCar.X;
            int carY = World.Instance.ControlledCar.Y;

            this.packet.DistanceX = carX - this.circleX;
            this.packet.DistanceY = carY - this.circleY;

        }
    }
}
