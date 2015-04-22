using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Snow.Web.RetailService
{
    [ServiceContract(Namespace = "http://snow.org/retailservice/2014/02/27", Name = "RetailService")]
    public interface IRetailService
    {
        [OperationContract(Name = "OpenSession")]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "open-session")]
        OpenSessionResponse OpenSession(OpenSessionRequest request);

        [OperationContract(Name = "GetCustomer")]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "get-customer")]
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
    }
}
