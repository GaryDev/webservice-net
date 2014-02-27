using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snow.Web.Controller
{
    public class RetailServiceController
    {
        public string SessionId { get; set; }
        public string ClientTime { get; set; }

        public RetailServiceController(string sessionId, string clientTime)
        {
            this.SessionId = sessionId;
            this.ClientTime = clientTime;
        }
        
        public RetailService.OpenSessionResponse OpenSession(RetailService.OpenSessionRequest request)
        {
            string sessionId = BLL.RetailServiceBLL.NewSession(request.LoginId, request.ComputerName);
            return new RetailService.OpenSessionResponse() { SessionId = sessionId };
        }

    }
}
