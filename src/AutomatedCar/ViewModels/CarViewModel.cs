namespace AutomatedCar.ViewModels
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CarViewModel : WorldObjectViewModel
    {
        public AutomatedCar Car { get; set; }
        public IReadOnlyDummyPacket DummyPacket { get; set; }
        public CarViewModel(AutomatedCar car) : base(car)
        {
            this.Car = car;
            this.DummyPacket = car.VirtualFunctionBus.DummyPacket;
        }
    }
}
