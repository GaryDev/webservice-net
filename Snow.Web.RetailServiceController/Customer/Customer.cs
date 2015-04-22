using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Snow.Web.RetailService
{
    [DataContract(Namespace = "http://snow.org/retailservice/datacontract/2014/02/27/", Name = "Customer")]
    public class Customer
    {
        [DataMember(Name = "CustomerId", Order = 1)]
        public int CustomerId { get; set; }

        [DataMember(Name = "CustomerCode", Order = 2)]
        public string CustomerCode { get; set; }

        [DataMember(Name = "FirstName", Order = 3)]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName", Order = 4)]
        public string LastName { get; set; }

        [DataMember(Name = "Telephone", Order = 5)]
        public string Telephone { get; set; }

        [DataMember(Name = "BirthDate", Order = 6)]
        public DateTime? BirthDate { get; set; }
    }
}
