using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snow.Web.BLL
{
    public static class ServiceContext
    {
        private static Dictionary<string, SessionContext> _sessionCollection = new Dictionary<string,SessionContext>();

        public static string NewSession(string loginId, string computerName)
        {
            string sessionId = Guid.NewGuid().ToString();
            SessionContext session = new SessionContext(computerName);
            _sessionCollection.Add(sessionId, session);
            return sessionId;
        }
    }
}
