namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    internal class DummySensor : SystemComponent
    {
        private int objX;
        private int objY;
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.objX = World.Instance.WorldObjects[0].X;
            this.objY = World.Instance.WorldObjects[0].Y;

            this.dummyPacket = new();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            this.objX = World.Instance.WorldObjects[0].X;
            this.objY = World.Instance.WorldObjects[0].Y;

            this.dummyPacket.DistanceX = this.objX - World.Instance.ControlledCar.X;
            this.dummyPacket.DistanceY = this.objY - World.Instance.ControlledCar.Y;
        }
    }
}
