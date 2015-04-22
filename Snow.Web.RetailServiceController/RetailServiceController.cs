using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snow.Web.RetailService;
using Snow.Web.BLL;

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
        
        public OpenSessionResponse OpenSession(OpenSessionRequest request)
        {
            string sessionId = RetailServiceBLL.NewSession(request.LoginId, request.ComputerName);
            return new RetailService.OpenSessionResponse() { SessionId = sessionId };
        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            GetCustomerResponse response = new GetCustomerResponse();

            DTO.CustomerList customerList = CustomerBLL.GetCustomer(request.VipCode);
            if (customerList != null)
                response.CustomerList = Mapper.Map<DTO.CustomerList, CustomerList>(customerList);

            return response;
        }
    }
}
