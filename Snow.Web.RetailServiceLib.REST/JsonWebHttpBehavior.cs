using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Configuration;

namespace Snow.Web.RetailServiceLib.REST
{
    public class JsonWebHttpBehavior : WebHttpBehavior
    {
        #region Protected Method(s)

        /// <summary>
        /// Add the json error handler to channel error handlers
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="endpointDispatcher"></param>
        protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            int errorHandlerCount = endpointDispatcher.ChannelDispatcher.ErrorHandlers.Count;
            base.AddServerErrorHandlers(endpoint, endpointDispatcher);
            IErrorHandler webHttpErrorHandler = endpointDispatcher.ChannelDispatcher.ErrorHandlers[errorHandlerCount];
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.RemoveAt(errorHandlerCount);
            JsonErrorHandler newHandler = new JsonErrorHandler(webHttpErrorHandler);
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(newHandler);
        }

        #endregion
    }

    public class JsonWebHttpBehaviorElement : BehaviorExtensionElement
    {
        /// <summary>
        /// Get the type of behavior to attach to the endpoint  
        /// </summary>
        public override Type BehaviorType
        {
            get
            {
                return typeof(JsonWebHttpBehavior);
            }
        }

        /// <summary>
        /// Create the custom behavior 
        /// </summary>
        /// <returns></returns>
        protected override object CreateBehavior()
        {
            return new JsonWebHttpBehavior();
        }
    }
}
