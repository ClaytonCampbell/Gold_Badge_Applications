using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Classes
{
    public class VehicleRepo
    {
        protected readonly List<Car> _contentDirectory = new List<Car>();
        public bool AddCar(Car car)
        {
            int startCount = _contentDirectory.Count;
            _contentDirectory.Add(car);
            bool added = (_contentDirectory.Count > startCount) ? true : false;
            return added;
        }
        public List<Car> GetCar()
        {
            return _contentDirectory;
        }
        public List<Car> GetCarByType(int z)
        {
            var carType = VehicleType.Gas;
            switch (z)
            {
                case 1:
                    carType = VehicleType.Electric;
                    Console.WriteLine("Electric Vehicles:\n");
                    break;
                case 2:
                    carType = VehicleType.Hybrid;
                    Console.WriteLine("Hybrid Vehicles:\n");
                    break;
                case 3:
                    carType = VehicleType.Gas;
                    Console.WriteLine("Gas Vehicles:\n");
                    break;
                default:
                    Console.WriteLine("Please choose a valid number next time. Here are the gas powered vehicles.\n");
                    break;
            }
            return _contentDirectory.Where(x => x.Type == carType).ToList();
        }
        public bool DeleteCar(Car currentCar)
        {
            bool delete = _contentDirectory.Remove(currentCar);
            return delete;
        }
    }
}
