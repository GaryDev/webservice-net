using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Provider;

namespace Snow.Web.DataProvider
{
    public class DataProviderCollection : ProviderCollection
    {
        # region Public Properties

        public new DataProvider this[string name]
        {
            get { return (DataProvider)base[name]; }
        }

        #endregion

        #region Public Members

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            //if (!(provider is DataSourceProvider))
            //    throw new ArgumentException("Invalid provider type", "provider");

            base.Add(provider);
        }

        #endregion
    }
}
