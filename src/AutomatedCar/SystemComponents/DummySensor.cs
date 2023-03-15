namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DummySensor : SystemComponent
    {
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
        }

        public override void Process()
        {
            var world = World.Instance;
            var car = world.ControlledCar;
            var circle = world.WorldObjects.First();
            var dummyPacket = virtualFunctionBus.DummyPacket as DummyPacket;

            dummyPacket.DistanceX = car.X - circle.X;
            dummyPacket.DistanceY = car.Y - circle.Y;
        }
    }
}
