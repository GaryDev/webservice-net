using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Snow.Web.RetailService
{
    [DataContract(Namespace = "http://snow.org/retailservice/datacontract/2014/02/27/", Name = "WebFault")]
    public class WebFault
    {
        #region Public Members

        [DataMember(Name = "Operation", Order = 0)]
        public string Operation { get; set; }

        [DataMember(Name = "Code", Order = 1)]
        public string Code { get; set; }

        [DataMember(Name = "Description", Order = 2)]
        public string Description { get; set; }

        [DataMember(Name = "Message", Order = 3)]
        public string Message { get; set; }

        [DataMember(Name = "FaultType", Order = 4)]
        public WebFaultType FaultType { get; set; }

        #endregion
    }

    [DataContract(Namespace = "http://snow.org/retailservice/datacontract/2014/02/27/", Name = "WebFaultType")]
    public enum WebFaultType
    {
        [EnumMember]
        UnknownFault = 0,
        [EnumMember]
        SessionFault,
        [EnumMember]
        DatabaseFault,
        [EnumMember]
        ConfigFault
    }
}
