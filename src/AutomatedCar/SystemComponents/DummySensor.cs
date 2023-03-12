namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DummySensor : SystemComponent
    {
        DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var circle = World.Instance.WorldObjects[0];
            var car = World.Instance.ControlledCar;
            int dist_x = car.X- circle.X;
            int dist_y = car.Y - circle.Y;

            this.dummyPacket.DistanceX= dist_x;
            this.dummyPacket.DistanceY= dist_y;
        }
    }
}
