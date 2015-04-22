using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Snow.Web.RetailService
{
    [DataContract(Namespace = "http://snow.org/retailservice/datacontract/2014/02/27/", Name = "CustomerList")]
    public class CustomerList
    {
        [DataMember(Name = "Customers", Order = 0)]
        public List<Customer> Customers { get; set; }

        [DataMember(Name = "TotalCount", Order = 1)]
        public int TotalCount { get; set; }
    }
}
