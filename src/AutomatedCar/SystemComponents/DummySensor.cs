namespace AutomatedCar.SystemComponents
{
    using System.Linq;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private int circlePosX;
        private int circlePosY;

        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus VFB)
            : base(VFB)
        {
            this.dummyPacket = new DummyPacket();
            VFB.DummyPacket = this.dummyPacket;
            var circle = World.Instance.WorldObjects.Where(x => nameof(x) == nameof(Circle)).FirstOrDefault();

            this.circlePosX = circle.X;
            this.circlePosY = circle.Y;
        }

        public override void Process()
        {
            var currentCar = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = this.circlePosX - currentCar.X;
            this.dummyPacket.DistanceY = this.circlePosY - currentCar.Y;
        }
    }
}
