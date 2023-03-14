namespace AutomatedCar.SystemComponents.Sensors
{
    using System;
    using System.Linq;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.virtualFunctionBus.DummyPacket = new DummyPacket();
        }

        public override void Process()
        {
            WorldObject circleObject = World.Instance.WorldObjects.FirstOrDefault();
            AutomatedCar controlledCar = World.Instance.ControlledCar;
            if ( circleObject != null && controlledCar != null)
            {
                (virtualFunctionBus.DummyPacket as DummyPacket).DistanceX = Math.Abs(circleObject.X - controlledCar.X);
                (virtualFunctionBus.DummyPacket as DummyPacket).DistanceY = Math.Abs(circleObject.Y - controlledCar.Y);
            }
        }
    }
}
