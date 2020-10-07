using _02_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge02
{
    public class UI
    {
        private readonly IConsole _console;
        private readonly CustomerRepo _repo = new CustomerRepo();
        public UI(IConsole console)
        {
            _console = console;
        }
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool running = true;
            while (running)
            {
                _console.Clear();
                _console.WriteLine("Choose your option: \n" +
                    "1) Add a customer \n" +
                    "2) Update a customer's info \n" +
                    "3) Delete customer Data \n" +
                    "4) Show customer Data \n" +
                    "5) Quit like a coward");
                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        NewCustomer();
                        break;
                    case "2":
                        UpdateCustomer();
                        break;
                    case "3":
                        RemoveCustomer();
                        break;
                    case "4":
                        ShowCustomer();
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
        private void NewCustomer()
        {
            Customer customer = new Customer();
            _console.WriteLine("Enter the first name.");
            string customerFirstName = _console.ReadLine();
            customer.FirstName = customerFirstName;

            _console.WriteLine("Enter the last name.");
            string customerLastName = _console.ReadLine();
            customer.LastName = customerLastName;

            _console.WriteLine("Select customer type: \n" +
                "1) Potential \n" +
                "2) Current \n" +
                "3) Past");
            string customerType = _console.ReadLine();
            switch (customerType)
            {
                case "1":
                    customer.Type = CustomerType.Potential;
                    break;
                case "2":
                    customer.Type = CustomerType.Current;
                    break;
                case "3":
                    customer.Type = CustomerType.Past;
                    break;
            }
            _repo.AddCustomer(customer);
        }
        private void UpdateCustomer()
        {
            _console.WriteLine("Which customer are you updating?");
            List<Customer> customerList = _repo.GetCustomers();
            int count = 0;
            foreach (var customer in customerList)
            {
                count++;
                _console.WriteLine($"{count}) {customer.FirstName} {customer.LastName}");
            }
            int targetCustomer = int.Parse(_console.ReadLine());
            int correct = targetCustomer - 1;
            if (correct >= 0 && correct < customerList.Count)
            {
                Customer expectedList = customerList[correct];
                _console.WriteLine("Enter the first name.");
                string customerFirstName = _console.ReadLine();
                expectedList.FirstName = customerFirstName;

                _console.WriteLine("Enter the last name.");
                string customerLastName = _console.ReadLine();
                expectedList.LastName = customerLastName;

                _console.WriteLine("Select customer type: \n" +
                    "1) Potential \n" +
                    "2) Current \n" +
                    "3) Past");
                string customerType = _console.ReadLine();
                switch (customerType)
                {
                    case "1":
                        expectedList.Type = CustomerType.Potential;
                        break;
                    case "2":
                        expectedList.Type = CustomerType.Current;
                        break;
                    case "4":
                        expectedList.Type = CustomerType.Past;
                        break;
                }
            }
            else
            {
                _console.WriteLine("Impossible Action");
            }
            _console.WriteLine("Press a key to continue.");
            _console.ReadKey();
        }
        private void ShowCustomer()
        {
            _console.Clear();
            List<Customer> listOfCustomers = _repo.GetCustomers();
            _console.WriteLine("First Name || Last Name  ||  Customer Type  ||  Email Message\n");
            foreach(Customer customer in listOfCustomers)
            {
                DisplayList(customer);
            }
            _console.WriteLine("\nEnd of List. Press key to continue.");
            _console.ReadKey();
         }
        private void RemoveCustomer()
        {
            _console.WriteLine("Which customer are you removing?");
            List<Customer> customerList = _repo.GetCustomers();
            int count = 0;
            foreach(var customer in customerList)
            {
                count++;
                _console.WriteLine($"{count}) {customer.FirstName} {customer.LastName}");
            }
            int targetCustomer = int.Parse(_console.ReadLine());
            int correct = targetCustomer - 1;
            if(correct >= 0 && correct < customerList.Count)
            {
                Customer expectedList = customerList[correct];
                if (_repo.DeleteCustomer(expectedList))
                {
                    _console.WriteLine($"{expectedList.FirstName} {expectedList.LastName} has been removed.");
                }
                else
                {
                    _console.WriteLine("Action cannot be completed.");
                }
            }
            else
            {
                _console.WriteLine("Impossible Action");
            }
            _console.WriteLine("Press a key to continue.");
            _console.ReadKey();
        }
        private void DisplayList(Customer customer)
        {
            _console.WriteLine($"{customer.FirstName} || {customer.LastName} ||  {customer.Type}  ||  {customer.Email}");
        }
    }
}
