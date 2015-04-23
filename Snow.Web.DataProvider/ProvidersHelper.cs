using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Provider;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Collections.Specialized;

namespace Snow.Web.DataProvider
{
    public static class ProvidersHelper
    {
        private static Type providerBaseType = typeof(ProviderBase);

        /// <summary>
        /// Instantiates the provider.
        /// </summary>
        /// <param name="providerSettings">The settings.</param>
        /// <param name="providerType">Type of the provider to be instantiated.</param>
        /// <returns></returns>
        public static ProviderBase InstantiateProvider(ProviderSettings providerSettings, Type providerType)
        {
            ProviderBase base2 = null;

            try
            {
                string str = (providerSettings.Type == null) ? null : providerSettings.Type.Trim();

                if (string.IsNullOrEmpty(str))
                {
                    throw new ArgumentException("Provider type name is invalid");
                }

                string appDir = null;

                // Unified way to get Application Path

                // if RelativeSearchPath is null or empty, check in normal way
                if (string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath))
                    appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                // otherwise check for web application
                else
                    appDir = AppDomain.CurrentDomain.RelativeSearchPath;

                NameValueCollection parameters = providerSettings.Parameters;
                NameValueCollection config = new NameValueCollection(parameters.Count, StringComparer.Ordinal);

                foreach (string str2 in parameters)
                {
                    config[str2] = parameters[str2];
                }

                string dll = config["assembly"].ToString();

                Assembly assembly = Assembly.LoadFile(appDir + "\\" + dll);

                Type type = assembly.GetType(str, true, true);

                if (!providerType.IsAssignableFrom(type))
                {
                    throw new ArgumentException(String.Format("Provider must implement type {0}.", providerType.ToString()));
                }

                base2 = (ProviderBase)Activator.CreateInstance(type);

                base2.Initialize(providerSettings.Name, config);
            }

            catch (Exception exception)
            {
                if (exception is ConfigurationException)
                {
                    throw;
                }

                throw new ConfigurationErrorsException(exception.Message,
                    providerSettings.ElementInformation.Properties["type"].Source,
                    providerSettings.ElementInformation.Properties["type"].LineNumber);
            }

            return base2;
        }

        public static void InstantiateProviders(ProviderSettingsCollection providerSettings, ProviderCollection providers, Type type)
        {
            foreach (ProviderSettings settings in providerSettings)
            {
                providers.Add(ProvidersHelper.InstantiateProvider(settings, type));
            }
        }
    }
}
