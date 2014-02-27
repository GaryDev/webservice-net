using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snow.Web.BLL
{
    public class RetailServiceBLL
    {

        public static string NewSession(string loginId, string computerName)
        {
            string sessionId = ServiceContext.NewSession(loginId, computerName);
            return sessionId;
        }

    }
}
