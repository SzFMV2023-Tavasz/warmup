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
        private int circlePosX;
        private int circlePosY;

        DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus VFB)
            : base(VFB)
        {
            this.dummyPacket = new DummyPacket();
            VFB.DummyPacket = this.dummyPacket;
            var circle = World.Instance.WorldObjects.Where(x => nameof(x) == nameof(Circle)).FirstOrDefault();
        }

        public override void Process()
        {
            var currentCar = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = this.circlePosX - currentCar.X;
            this.dummyPacket.DistanceY = this.circlePosY - currentCar.Y;
        }
    }
}
