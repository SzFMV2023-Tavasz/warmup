namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System.Linq;

    public class DummySensor : SystemComponent
    {
        DummyPacket dummyPacket;
        
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            dummyPacket = new DummyPacket();
            GetCircle();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
            virtualFunctionBus.RegisterComponent(this);
        }
        int circle_x;
        int circle_y;
        private void GetCircle() 
        {
            var circle = World.Instance.WorldObjects.Where(x => x is Circle).FirstOrDefault();

            this.circle_x = circle.X;
            this.circle_y = circle.Y;
        }
        public override void Process()
        {
            int carX = World.Instance.ControlledCar.X;
            int carY = World.Instance.ControlledCar.Y;

            dummyPacket.DistanceX = circle_x - carX;
            dummyPacket.DistanceY = circle_y - carY;
            
        }
    }
}
