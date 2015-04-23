using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snow.Web.DTO;
using Snow.Web.DataProvider;

namespace Snow.Web.BLL
{
    public class CustomerBLL
    {
        public static CustomerList GetCustomer(string vipCode)
        {
            return DataService.GetCustomer(vipCode);
        }
    }
}
