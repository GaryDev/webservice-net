using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Snow.Web.RetailService
{
    [DataContract(Namespace = "http://snow.org/retailservice/datacontract/2014/02/27/", Name = "GetCustomerRequest")]
    public class GetCustomerRequest
    {
        [DataMember(Name = "VipCode", Order = 0)]
        public string VipCode { get; set; }
    }

    [DataContract(Namespace = "http://snow.org/retailservice/datacontract/2014/02/27/", Name = "GetCustomerResponse")]
    public class GetCustomerResponse
    {
        [DataMember(Name = "CustomerList", Order = 0)]
        public CustomerList CustomerList { get; set; }
    }
}
