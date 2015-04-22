using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snow.Web.DTO
{
    public class Customer
    {
        private int _customerId;
        private string _customerCode;
        private string _firstName;
        private string _lastName;
        private string _telephone;
        private DateTime? _birthdate;

        public Customer()
        { 
        
        }

        public Customer(string customerCode) : this()
        {
            _customerCode = customerCode;
        }
        
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public string CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public DateTime? BirthDate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }
    }
}
