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
        private DummyPacket dummyPacket;
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var mKor = World.Instance.WorldObjects[0];
            var mAuto = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = mAuto.X - mKor.X;
            this.dummyPacket.DistanceY = mAuto.Y - mKor.Y;

        }
    }
}
