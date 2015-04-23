using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snow.Web.DTO;
using System.Data.Common;
using System.Data;

namespace Snow.Web.DataProvider
{
    public partial class DataService
    {
        public static CustomerList GetCustomer(string vipCode)
        {            
            return DataProvider.GetCustomer(vipCode);
        }
    }
}
