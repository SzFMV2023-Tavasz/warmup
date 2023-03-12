namespace AutomatedCar.ViewModels
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CarViewModel : WorldObjectViewModel
    {
        public VirtualFunctionBus VirtualFunctionBus { get; set; }

        public AutomatedCar Car { get; set; }
        public CarViewModel(AutomatedCar car) : base(car)
        {
            this.Car = car;
            this.VirtualFunctionBus = Car.VirtualFunctionBus;
        }
    }
}
