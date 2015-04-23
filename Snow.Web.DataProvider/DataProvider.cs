using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snow.Web.DTO;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Configuration;

namespace Snow.Web.DataProvider
{
    public abstract class DataProvider : ProviderBase
    {
        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
                throw new ArgumentNullException("config");

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
                name = "mssqlDataProvider";

            // Add a default "description" attribute to config if the attribute doesn't exist or is empty
            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sql Server Data Provider");
            }

            base.Initialize(name, config);

            // Initialize _connectionString
            string connect = config["connectionStringName"];

            if (String.IsNullOrEmpty(connect))
                throw new ProviderException("Empty or missing connectionStringName");

            config.Remove("connectionStringName");

            if (ConfigurationManager.ConnectionStrings[connect] == null)
                throw new ProviderException("Missing connection string");

            _connectionString = ConfigurationManager.ConnectionStrings[connect].ConnectionString;

            if (String.IsNullOrEmpty(_connectionString))
                throw new ProviderException("Empty connection string");

            config.Remove("assembly");

            // Throw an exception if unrecognized attributes remain
            if (config.Count > 0)
            {
                string attribute = config.GetKey(0);
                if (!String.IsNullOrEmpty(attribute))
                    throw new ProviderException("Unrecognized attribute: " + attribute);
            }
        }
        
        public abstract CustomerList GetCustomer(string vipCode);
    }
}
