using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snow.Web.DTO
{
    public class CustomerList
    {
        private List<Customer> _customers;
        private int _totalCount;

        public CustomerList()
        {
            _customers = new List<Customer>();
        }

        public List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }
    }
}
