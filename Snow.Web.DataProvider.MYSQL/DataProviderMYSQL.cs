using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snow.Web.DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Snow.Web.DataProvider.MYSQL
{
    public class DataProviderMYSQL : DataProvider
    {
        public override CustomerList GetCustomer(string vipCode)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("swSP_GetCustomer", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    MySqlParameter param = new MySqlParameter("?vip_code", MySqlDbType.String);
                    param.Direction = ParameterDirection.Input;
                    param.Value = vipCode;
                    cmd.Parameters.Add(param);

                    cmd.Connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.CustomerId = Convert.ToInt32(reader["vipcode_id"]);
                            customer.CustomerCode = reader["vipcode"] as string;
                            customer.FirstName = reader["vipgname"] as string;
                            customer.LastName = reader["vipname"] as string;
                            customer.Telephone = reader["telephone"] as string;
                            if (reader["birthday"] != DBNull.Value)
                                customer.BirthDate = Convert.ToDateTime(reader["birthday"]);

                            customers.Add(customer);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            CustomerList customerList = new CustomerList();
            customerList.Customers = customers;
            customerList.TotalCount = customers.Count;
            return customerList;
        }
    }
}
