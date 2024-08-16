using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCPSY200.Data
{
    public class Rental
    {
        int rentalID;
        int customerID;
        int date;
        int item;

        public int RentalID { get => rentalID; set => rentalID = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public int Date { get => date; set => date = value; }
        public int Item { get => item; set => item = value; }

        public Rental()
        {
            
        }
        public Rental(int rentalID, int customerID, int date, int item)
        {
            this.rentalID = rentalID;
            this.customerID = customerID;
            this.date = date;
            this.item = item;
        }
    }
}
