using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snow.Web.DataProvider;
using System.Configuration;
using System.Configuration.Provider;

namespace Snow.Web.DataProvider
{
    public partial class DataService
    {
        private static DataProvider _provider = null;
        private static DataProviderCollection _providers = null;
        private static object _lock = new object();

        public static DataProvider DataProvider
        {
            get
            {
                // Make sure a provider is loaded
                // Avoid claiming lock if providers are already loaded
                if (_provider == null)
                {
                    lock (_lock)
                    {
                        // Do this again to make sure _provider is still null
                        if (_provider == null)
                        {
                            // Get a reference to the <decisionService> section
                            DataServiceSection section = (DataServiceSection)ConfigurationManager.GetSection("DataService");
                            if (section == null)
                                throw new ConfigurationErrorsException("Unable to find section: DataService");

                            // Load registered providers and point _provider to the default provider
                            _providers = new DataProviderCollection();
                            ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(DataProvider));
                            _provider = (DataProvider)_providers[section.DefaultProvider];

                            if (_provider == null)
                                throw new ProviderException("Unable to load default DataProvider");
                        }
                    }
                }
                
                return _provider;
            }
        }

        public static DataProviderCollection Providers
        {
            get { return _providers; }
        }

    }
}
