using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Classes
{
    public enum CustomerType
        {
            Potential,
            Current,
            Past
        }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        
        public CustomerType Type { get; set; }
        public string Email { 
            get 
            {
                switch (Type)
                {
                    case CustomerType.Potential:
                        string potential = "We currently have the lowest rates on Helicopter Insurance!";
                        return potential;
                    case CustomerType.Current:
                        string current = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                        return current;
                    case CustomerType.Past:
                        string past = "It's been a long time since we've heard from you, we want you back.";
                        return past;
                    default:
                        string reply = "Error.";
                        return reply;

                }
            }
        }
    }
}
