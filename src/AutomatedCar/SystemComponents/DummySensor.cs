namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var circle = (Circle)World.Instance.WorldObjects.Where(worldObject => worldObject is Circle).First();
            var car = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = Math.Abs(circle.X - car.X) - circle.Radius;
            this.dummyPacket.DistanceY = Math.Abs(circle.Y - car.Y) - circle.Radius;
        }
    }
}
