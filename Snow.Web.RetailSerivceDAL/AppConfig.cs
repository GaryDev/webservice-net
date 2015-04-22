using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Snow.Web.DAL
{
    public class AppConfig
    {
        private static AppConfig _instance = new AppConfig();

        public static AppConfig Instance
        {
            get { return _instance; }
        }

        public string ConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["dbConnection"] != null)
                    return ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
                else
                    return null;
            }
        }
    }
}
