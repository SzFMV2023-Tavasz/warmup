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
        public DummyPacket dummyPacket { get; set; }
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var car = World.Instance.ControlledCar;
            var circle = World.Instance.WorldObjects.FirstOrDefault();
            dummyPacket.DistanceX = Math.Abs(car.X - circle.X);
            dummyPacket.DistanceY = Math.Abs(car.Y - circle.Y);
        }
    }
}
