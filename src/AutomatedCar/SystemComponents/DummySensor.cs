namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus): base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var cirle = World.Instance.WorldObjects[0];
            var controlled_car = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = controlled_car.X - cirle.X;
            this.dummyPacket.DistanceY = controlled_car.Y - cirle.Y;
        }
    }
}
