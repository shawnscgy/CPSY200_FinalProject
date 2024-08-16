using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCPSY200.Data
{
    public class Customer
    {
        int customerID;
        string firstName;
        string lastName;
        string contactPhone;
        string email;
        string note;

        public int CustomerID { get => customerID; set => customerID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string ContactPhone { get => contactPhone; set => contactPhone = value; }
        public string Email { get => email; set => email = value; }
        public string Note { get => note; set => note = value; }

        public Customer()
        {

        }

        // Constructor without note as parameter
        public Customer(int customerID, string firstName, string lastName, string contactPhone, string email)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.contactPhone = contactPhone;
            this.email = email;
        }
        public Customer(int customerID, string firstName, string lastName, string contactPhone, string email, string note)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.contactPhone = contactPhone;
            this.email = email;
            this.note = note;
        }


    }
}
