using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProjectCPSY200.Data
{
    public class DataConnection
    {
        string connString;
        SqlConnection sqlConnection;
        public DataConnection()
        {
            connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VillageRentals;Integrated Security=True";
            sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
        }


        // Category
        public string insertCategory(int id, string name)
        {
            string insertQuery = "Insert into Categories (categoryid, category_name) values (" + id + ",'" + name + "');";

            using (SqlCommand sql = new SqlCommand(insertQuery, sqlConnection))
            {
                try
                {
                    int row = sql.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "Successfully added";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                return "Failed";
            }



        }

        // Customer
        public Customer searchCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "Select * from Customers where customerid = " + id + ";";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // read one record at a time
                    {
                        customer.CustomerID = (int)reader.GetValue(0);
                        customer.LastName = (string)reader.GetValue(1);
                        customer.FirstName = (string)reader.GetString(2);
                        customer.ContactPhone = (string)reader.GetString(3);
                        customer.Email = (string)reader.GetValue(4);
                        customer.Note = (string)reader.GetValue(5);
                    }
                }
            }
            return customer;
        }
        public string insertCustomer(int id, string lastname, string firstname, string contactphone, string email, string note)
        {

            string insertQuery = "Insert into Customers (customerid, last_name, first_name, contact_phone, email, note) values ("
                + id + ",'" + lastname + "', '" + firstname + "', '" + contactphone + "', '" + email + "', '" + note + "');";
            using (SqlCommand sql = new SqlCommand(insertQuery, sqlConnection))
            {
                try
                {
                    int row = sql.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "Successfully added";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                return "Failed";
            }
        }
        public string updateCustomer(int id, string lastname, string firstname, string contactphone, string email, string note)
        {
            string updateQuery = "update Customers set last_name = '" + lastname + "', first_name = '" + firstname
                + "', contact_phone = '" + contactphone + "', email = '" + email + "', note = '" + note + "' "
                + "where customerid = " + id + ";";
            using (SqlCommand sql = new SqlCommand(updateQuery, sqlConnection))
            {
                try
                {
                    int row = sql.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "Successfully updated";
                    }
                    else
                    {
                        return "Failed to update";
                    }
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                return "Failed to update";
            }
        }
        public void delete()
        {
            int id;
            Console.WriteLine("Enter ID that you would like to delete");
            id = int.Parse(Console.ReadLine());
            string deleteQuery = "Delete from book where id=" + id;
            SqlCommand sql = new SqlCommand(deleteQuery, sqlConnection);
            sql.ExecuteNonQuery();
            Console.WriteLine("Data deleted Successfully");
        }

        public List<string> displayAllCustomers()
        {
            List<string> customers = new List<string>();
            string item;
            string sql = "Select * from Customers;";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // read one record at a time
                    {
                        item = $" CustomerID: {reader["customerid"]} LastName: {reader["last_name"]} FirstName: {reader["first_name"]} ContactPhone: {reader["contact_phone"]}  Email: {reader["email"]}  Note: {reader["note"]}\n";
                        customers.Add(item);
                    }

                }
            }

            return customers;
        }


        // Equipment
        public string insertEquipment(int equipmentid, int categoryid, string name, string description, float dailyrate)
        {

            string insertQuery = "Insert into Equipments (equipmentid, categoryid, name, description, daily_rate) values ("
                + equipmentid + "," + categoryid + ", '" + name + "', '" + description + "', " + dailyrate + ");";
            using (SqlCommand sql = new SqlCommand(insertQuery, sqlConnection))
            {
                try
                {
                    int row = sql.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "Successfully added";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                return "Failed";
            }
        }
        public Equipment searchEquipment(int id)
        {
            Equipment equipment = new Equipment();
            string sql = "Select * from Equipments where equipmentid = " + id + ";";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // read one record at a time
                    {
                        equipment.EquipmentID = (int)reader.GetValue(0);
                        equipment.Category = (int)reader.GetValue(1);
                        equipment.EquipmentName = (string)reader.GetString(2);
                        equipment.Description = (string)reader.GetString(3);
                        equipment.DailyRentalCost = Convert.ToSingle(reader.GetValue(4));
                    }
                }
            }
            return equipment;
        }
        public string removeEquipment(int id)
        {
            string removeQuery = "Delete from Equipments where equipmentid = " + id + ";";
            using (SqlCommand sql = new SqlCommand(removeQuery, sqlConnection))
            {
                try
                {
                    int row = sql.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "Successfully deleted";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                return "Failed";
            }
        }
        public List<string> displayAllEquipments() 
        {
            List<string> equipments = new List<string>();
            string item;
            string sql = "Select * from Equipments;";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) // read one record at a time
                    {
                        item = $" EquipmentID: {reader["equipmentid"]} CategoryID: {reader["categoryid"]} Name: {reader["name"]} Description: {reader["description"]}  Daily Rate: {reader["daily_rate"]}\n";
                        equipments.Add(item);
                    }

                }
            }

            return equipments;
        }

        // Rental
        public string insertRental(int rentalid, int date, int customerid, int equipmentid, int rentaldate, int returndate)
        {
            
            string insertQuery = "Insert into Rentals (rentalid, customerid, equipmentid, date) values ("
               + rentalid + "," + customerid + ", " + equipmentid + ", " + date + ");";
            
            using (SqlCommand sql = new SqlCommand(insertQuery, sqlConnection))
            {
                try
                {
                    int row = sql.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "Successfully added";
                    }
                    else
                    {
                        return "Insert Rental Failed";
                    }
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                return "Failed. Error";
            }
        }
        public string insertRentalItem(int rentalid, int equipmentid, int rentaldate, int returndate)
        {
            string insertQuery = "Insert into dbo.RentalItems (rentalid, equipmentid, rental_date, return_date) values (" 
                + rentalid + ", " + equipmentid + "," + rentaldate + ", " + returndate + ");";


            using (SqlCommand sql = new SqlCommand(insertQuery, sqlConnection))
            {
                try
                {
                    int row = sql.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "Successfully added Item";
                    }
                    else
                    {
                        return "Item Add Failed(existed)";
                    }
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                return "Item add Failed without executing, test:" + rentalid+ equipmentid+ rentaldate+ returndate;
            }
        }

        public void disconnect()
        {
            sqlConnection.Close();
        }
    }
}
