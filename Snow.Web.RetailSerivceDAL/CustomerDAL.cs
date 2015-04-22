using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snow.Web.DTO;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Snow.Web.DAL
{
    public partial class DataService
    {
        public static CustomerList GetCustomer(string vipCode)
        {
            SqlDatabase database = new SqlDatabase(_connectionStr);
            DbCommand command = database.GetStoredProcCommand("rmSP_WSPOS_GetCustomer");
            command.CommandTimeout = 300;
            database.AddInParameter(command, "@VipCode", DbType.String, vipCode);

            List<Customer> customers = new List<Customer>();
            using (IDataReader reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerId = Convert.ToInt32(reader["VIPCode_id"]);
                    customer.CustomerCode = reader["VipCode"] as string;
                    customer.FirstName = reader["VIPGName"] as string;
                    customer.LastName = reader["VIPName"] as string;
                    customer.Telephone = reader["VIPTel"] as string;
                    if (reader["VIPBDay"] != DBNull.Value)
                        customer.BirthDate = Convert.ToDateTime(reader["VIPBDay"]);
                    
                    customers.Add(customer);
                }
            }

            CustomerList customerList = new CustomerList();
            customerList.Customers = customers;
            customerList.TotalCount = customers.Count;
            return customerList;
        }
    }
}
