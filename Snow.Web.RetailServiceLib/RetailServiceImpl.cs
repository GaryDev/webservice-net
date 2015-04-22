using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Snow.Web.RetailService
{
    [ServiceBehavior(Name = "RetailServiceImpl", 
                    Namespace = "http://snow.org/retailservice/2014/02/27", 
                    InstanceContextMode = InstanceContextMode.PerCall)]
    public class RetailServiceImpl : IRetailService
    {
        private Controller.RetailServiceController _serviceController;

        public RetailServiceImpl()
        {
            string sessionId = null;
            string clientTime = null;
            
            HttpRequestMessageProperty httpRequestMessageProperty = OperationContext.Current.IncomingMessageProperties["httpRequest"] as HttpRequestMessageProperty;
            foreach (string key in httpRequestMessageProperty.Headers.AllKeys)
            {
                if (string.Equals(key, "SessionId", StringComparison.OrdinalIgnoreCase))
                    sessionId = httpRequestMessageProperty.Headers["SessionId"];

                if (string.Equals(key, "ClientTime", StringComparison.OrdinalIgnoreCase))
                    clientTime = httpRequestMessageProperty.Headers["ClientTime"];
            }

            this._serviceController = new Controller.RetailServiceController(sessionId, clientTime);
        }
        
        public OpenSessionResponse OpenSession(OpenSessionRequest request)
        {
            return _serviceController.OpenSession(request);
        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            return _serviceController.GetCustomer(request);
        }
    }
}
