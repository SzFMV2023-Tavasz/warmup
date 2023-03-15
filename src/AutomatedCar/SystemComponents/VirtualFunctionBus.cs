namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.SystemComponents.Packets;
    using System.Collections.Generic;

    public class VirtualFunctionBus : GameBase
    {
        public VirtualFunctionBus()
        {
            DummyPacket = new DummyPacket();
        }

        private List<SystemComponent> components = new List<SystemComponent>();
        public IReadOnlyDummyPacket DummyPacket { get; set; }

        public void RegisterComponent(SystemComponent component)
        {
            this.components.Add(component);
        }

        protected override void Tick()
        {
            foreach (SystemComponent component in this.components)
            {
                component.Process();
            }
        }
    }
}