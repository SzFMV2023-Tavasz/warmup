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
        DummyPacket dummyPacket = new DummyPacket();
        int circleX;
        int circleY;
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            virtualFunctionBus.DummyPacket = this.dummyPacket;
            virtualFunctionBus.RegisterComponent(this);

            var circle = World.Instance.WorldObjects.Find(x => x is Circle);
            this.circleX = circle.X;
            this.circleY = circle.Y;
            
        }

        public override void Process()
        {

            
            dummyPacket.DistanceX= circleX- World.Instance.ControlledCar.X;
            dummyPacket.DistanceY= circleY-World.Instance.ControlledCar.Y;
        }
    }
}
