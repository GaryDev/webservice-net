using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using Snow.Web.RetailService;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;

namespace Snow.Web.RetailServiceLib.REST
{
    public class JsonErrorHandler : IErrorHandler
    {
        private IErrorHandler _originalErrorHangHandler;

        public JsonErrorHandler(IErrorHandler originalErrorHandler)
        {
            this._originalErrorHangHandler = originalErrorHandler;
        }

        #region Public Methods

        #region IErrorHandler Members

        public bool HandleError(Exception error)
        {
            // Only log error if it's not handled from code
            if (error is WebFaultException<WebFault>)
                return this._originalErrorHangHandler.HandleError(error);
            else
            {
                // Log serialization error
                //_logger.ErrorFormat("{0}", error);
                return true;
            }
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            // Only generate JSON error if it's not handled from code
            if (error is WebFaultException<WebFault>)
                this._originalErrorHangHandler.ProvideFault(error, version, ref fault);
            else
            {
                fault = this.GetJsonFaultMessage(version, error);

                this.ApplyJsonSettings(ref fault);
                this.ApplyHttpResponseSettings(ref fault, System.Net.HttpStatusCode.BadRequest, "Exception in custom error handler");
            }
        }

        #endregion

        #endregion

        #region Protected Methods

        /// <summary>
        /// Apply Json settings to the message 
        /// </summary>
        /// <param name="fault"></param>
        protected virtual void ApplyJsonSettings(ref Message fault)
        {
            // Use JSON encoding  
            var jsonFormatting =
              new WebBodyFormatMessageProperty(WebContentFormat.Json);
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, jsonFormatting);
        }

        /// <summary>
        /// Get the HttpResponseMessageProperty 
        /// </summary>
        /// <param name="fault"></param>
        /// <param name="statusCode"></param>
        /// <param name="statusDescription"></param>
        protected virtual void ApplyHttpResponseSettings(ref Message fault, System.Net.HttpStatusCode statusCode, string statusDescription)
        {
            var httpResponse = new HttpResponseMessageProperty()
            {
                StatusCode = statusCode,
                StatusDescription = statusDescription
            };
            fault.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);
        }

        /// <summary>
        /// Get the json fault message from the provided error
        /// </summary>
        /// <param name="version"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        protected virtual Message GetJsonFaultMessage(MessageVersion version, Exception error)
        {
            var knownTypes = new List<Type>();
            string faultType = error.GetType().Name; //default  

            WebFault jsonFault = new WebFault
            {

                Code = "CustomErrorHandlerException",
                Description = string.Format("Exception caught in custom error handler. Type: {0}", faultType),
                Message = error.ToString(),
                Operation = "",
                FaultType = WebFaultType.UnknownFault
            };

            var faultMessage = Message.CreateMessage(version, "", jsonFault,
              new DataContractJsonSerializer(jsonFault.GetType(), knownTypes));

            return faultMessage;
        }

        #endregion

    }
}
