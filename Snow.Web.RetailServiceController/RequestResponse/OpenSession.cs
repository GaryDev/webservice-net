using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Snow.Web.RetailService
{
    [DataContract(Namespace = "http://snow.org/retailservice/2014/02/27/")]
    public class OpenSessionRequest
    {
        [DataMember(Name = "LoginId", Order = 0)]
        public string LoginId { get; set; }
        [DataMember(Name = "ComputerName", Order = 1)]
        public string ComputerName { get; set; }
    }

    [DataContract(Namespace = "http://snow.org/retailservice/2014/02/27/")]
    public class OpenSessionResponse
    {
        [DataMember(Name = "SessionId", Order = 0)]
        public string SessionId { get; set; }
    }
}
