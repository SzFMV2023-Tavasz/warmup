namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket packet;

        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.packet = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.packet;
        }

        public override void Process()
        {
            int circleX = World.Instance.WorldObjects[0].X;
            int circleY = World.Instance.WorldObjects[0].Y;

            int carX = World.Instance.ControlledCar.X;
            int carY = World.Instance.ControlledCar.Y;

            this.packet.DistanceX = carX - circleX;
            this.packet.DistanceY = carY - circleY;
        }
    }
}
