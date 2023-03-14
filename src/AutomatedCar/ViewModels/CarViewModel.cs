namespace AutomatedCar.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents;

    public class CarViewModel : WorldObjectViewModel
    {
        public AutomatedCar Car { get; set; }
        public CarViewModel(AutomatedCar car) : base(car)
        {
            this.Car = car;
        }

        public VirtualFunctionBus VirtualFunctionBus
        {
            get
            {
                return this.Car.VirtualFunctionBus;
            }
        }
    }
}
