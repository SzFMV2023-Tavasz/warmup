namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            WorldObject circleObject = World.Instance.WorldObjects[0];
            AutomatedCar carObject = World.Instance.ControlledCar;
            this.dummyPacket.DistanceX = carObject.X - circleObject.X;
            this.dummyPacket.DistanceY = carObject.Y - circleObject.Y;
        }
    }
}
