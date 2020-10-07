using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Classes
{
    public enum VehicleType
    {
        Electric,
        Hybrid,
        Gas,
        NA
    }
    public class Car
    {
        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public double Price { get; set; }
        public Car(){}
        public Car(VehicleType vehicleType, string model, int mileage, double price)
        {
            Type = vehicleType;
            Model = model;
            Mileage = mileage;
            Price = price;
        }
    }
}
