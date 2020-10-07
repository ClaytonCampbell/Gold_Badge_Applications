using System;
using _03_Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBade03
{
    public class UI
    {
        private readonly IConsole _console;
        private readonly VehicleRepo _repo = new VehicleRepo();
        public UI(IConsole console)
        {
            _console = console;
        }
        public void Run()
        {
            SeedCar();
            RunMenu();
        }
        private void SeedCar()
        {
            var carOne = new Car(VehicleType.Electric, "Ultima", 43, 30000);
            var carTwo = new Car(VehicleType.Gas, "Pickup", 44, 33000);
            var carThree = new Car(VehicleType.Hybrid, "Prius", 45, 32000);
            var carFour = new Car(VehicleType.Electric, "Camry", 46, 31000);
            _repo.AddCar(carOne);
            _repo.AddCar(carTwo);
            _repo.AddCar(carThree);
            _repo.AddCar(carFour);
        }
        private void RunMenu()
        {
            bool running = true;
            while (running)
            {
                _console.Clear();
                _console.WriteLine("Select an option: \n" +
                    "1) Add a new car\n" +
                    "2) Look at cars\n" +
                    "3) Update a car\n" +
                    "4) Delete a car\n" +
                    "5) Exit Application");
                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        NewCar();
                        break;
                    case "2":
                        ShowCarsByType();
                        break;
                    case "3":
                        UpdateCar();
                        break;
                    case "4":
                        RemoveCar();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        _console.WriteLine("Please choose a correct number.");
                        _console.ReadKey();
                        break;
                }
            }
        }
        private void NewCar()
        {
            Car car = new Car();
            var engineType = VehicleType.NA;
            while (engineType == VehicleType.NA)
            {
                _console.WriteLine("Select car type: \n" +
                    "1) Electric \n" +
                    "2) Hybrid \n" +
                    "3) Gas");
                string carType = _console.ReadLine();
                switch (carType)
                {
                    case "1":
                        car.Type = VehicleType.Electric;
                        engineType = VehicleType.Electric;
                        break;
                    case "2":
                        car.Type = VehicleType.Hybrid;
                        engineType = VehicleType.Hybrid;
                        break;
                    case "3":
                        car.Type = VehicleType.Gas;
                        engineType = VehicleType.Gas;
                        break;
                    default:
                        _console.Clear();
                        _console.WriteLine("Please select a valid engine type.\n");
                        break;
                }
            }
            _console.WriteLine("Enter the car Model name:");
            string modelName = _console.ReadLine();
            car.Model = modelName;
            _console.WriteLine("Enter the gas Mileage:");
            int mpg = Int32.Parse(Console.ReadLine());
            car.Mileage = mpg;
            _console.WriteLine("Enter the model's price:");
            double price = Double.Parse(Console.ReadLine());
            car.Price = price;
            _repo.AddCar(car);
        }
        private void UpdateCar()
        {
            _console.WriteLine("Which car type are you updating?\n" +
                "1) Electric\n" +
                "2) Hybrid\n" +
                "3) Gas\n");
            int x = Int32.Parse(_console.ReadLine());
            _console.Clear();
            List<Car> carList = _repo.GetCarByType(x);
            int count = 0;
            foreach(var car in carList)
            {
                count++;
                _console.WriteLine($"Selection {count})   Name: {car.Model}");
            }
            int targetCar = int.Parse(_console.ReadLine());
            int correctCar = targetCar - 1;
            if (correctCar>= 0 && correctCar < carList.Count)
            {
                Car expectedCar = carList[correctCar];
                var engineType = VehicleType.NA;
                while (engineType == VehicleType.NA)
                {
                    _console.WriteLine("Select car type: \n" +
                        "1) Electric \n" +
                        "2) Hybrid \n" +
                        "3) Gas");
                    string carType = _console.ReadLine();
                    switch (carType)
                    {
                        case "1":
                            expectedCar.Type = VehicleType.Electric;
                            engineType = VehicleType.Electric;
                            break;
                        case "2":
                            expectedCar.Type = VehicleType.Hybrid;
                            engineType = VehicleType.Hybrid;
                            break;
                        case "3":
                            expectedCar.Type = VehicleType.Gas;
                            engineType = VehicleType.Gas;
                            break;
                        default:
                            _console.Clear();
                            _console.WriteLine("Please select a valid engine type.\n");
                            break;
                    }
                }
                _console.WriteLine("Enter the car's model name:");
                string carModel = _console.ReadLine();
                expectedCar.Model = carModel;
                _console.WriteLine("Enter the Miles per Gallon:");
                int mpg = Int32.Parse(_console.ReadLine());
                expectedCar.Mileage = mpg;
                _console.WriteLine("Enter the car's price:");
                double price = Double.Parse(_console.ReadLine());
                expectedCar.Price = price;
            }
            else
            {
                _console.WriteLine("Impossible Action");
            }
            _console.WriteLine("Press a key to continue.");
            _console.ReadKey();
        }

        private void ShowCarsByType()
        {
            _console.Clear();
            _console.WriteLine("Please select a vehicle type: \n" +
                "1) Electric\n" +
                "2) Hybrid\n" +
                "3) Gas\n");
            int x = Int32.Parse(_console.ReadLine());
            _console.Clear();
            List<Car> selectCars = _repo.GetCarByType(x);
            foreach (Car car in selectCars)
            {
                DisplayCars(car);
            }
            _console.WriteLine("\nEnd of List. Press key to continue.");
            _console.ReadKey();
        }
        private void DisplayCars(Car car)
        {
            _console.WriteLine($"{car.Model} \n" +
                $"MPG: {car.Mileage}\n" +
                $"Price: ${car.Price}\n");
        }
        private void RemoveCar()
        {
            _console.WriteLine("Which car type are you removing?\n" +
                "1) Electric\n" +
                "2) Hybrid\n" +
                "3) Gas\n");
            int x = Int32.Parse(_console.ReadLine());
            _console.Clear();
            List<Car> carList = _repo.GetCarByType(x);
            int count = 0;
            foreach (var car in carList)
            {
                count++;
                _console.WriteLine($"Price: ${car.Price}   Name: {car.Model}   Mpg: {car.Mileage}");
            }
            int targetCar = int.Parse(_console.ReadLine());
            int correctCar = targetCar - 1;
            if(correctCar >= 0 && correctCar < carList.Count)
            {
                Car expectedCar = carList[correctCar];
                if (_repo.DeleteCar(expectedCar))
                {
                    _console.WriteLine($"{expectedCar.Model} has been deleted.");
                }
                else
                {
                    _console.WriteLine("Action cannot be completed.");
                }
            }
            else
            {
                _console.WriteLine("Cannot be done.");
            }
            _console.WriteLine("Press a key to continue.");
            _console.ReadKey();
        }
    }
}
