using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snow.Web.BLL
{
    public class SessionContext
    {
        private DateTime _timestamp;
        private string _computerName;

        public SessionContext()
        {
            this._timestamp = DateTime.Now;
        }

        public SessionContext(string computerName) : this()
        {
            this._computerName = computerName;
        }
    }
}
