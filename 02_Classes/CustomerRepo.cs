using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Classes
{
    public class CustomerRepo
    {
        protected readonly List<Customer> _contentDirectory = new List<Customer>();
        public bool AddCustomer(Customer customer)
        {
            int startCount = _contentDirectory.Count;
            _contentDirectory.Add(customer);
            bool added = (_contentDirectory.Count > startCount) ? true : false;
            return added;
        }
        public List<Customer> GetCustomers()
        {  
            return _contentDirectory.OrderBy(arr => arr.LastName).ThenBy(arr => arr.FirstName).ToList(); ;
        }
        public bool DeleteCustomer(Customer currentCustomer)
        {
            bool delete = _contentDirectory.Remove(currentCustomer);
            return delete;
        }
    }
}
