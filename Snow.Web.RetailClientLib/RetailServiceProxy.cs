﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5472
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://snow.org/retailservice/2014/02/27/", ClrNamespace="snow.org.retailservice._2014._02._27")]

namespace snow.org.retailservice._2014._02._27
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpenSessionRequest", Namespace="http://snow.org/retailservice/2014/02/27/")]
    public partial class OpenSessionRequest : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string LoginIdField;
        
        private string ComputerNameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoginId
        {
            get
            {
                return this.LoginIdField;
            }
            set
            {
                this.LoginIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string ComputerName
        {
            get
            {
                return this.ComputerNameField;
            }
            set
            {
                this.ComputerNameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpenSessionResponse", Namespace="http://snow.org/retailservice/2014/02/27/")]
    public partial class OpenSessionResponse : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string SessionIdField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SessionId
        {
            get
            {
                return this.SessionIdField;
            }
            set
            {
                this.SessionIdField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://snow.org/retailservice/2014/02/27", ConfigurationName="RetailService")]
public interface RetailService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://snow.org/retailservice/2014/02/27/RetailService/OpenSession", ReplyAction="http://snow.org/retailservice/2014/02/27/RetailService/OpenSessionResponse")]
    snow.org.retailservice._2014._02._27.OpenSessionResponse OpenSession(snow.org.retailservice._2014._02._27.OpenSessionRequest request);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface RetailServiceChannel : RetailService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class RetailServiceClient : System.ServiceModel.ClientBase<RetailService>, RetailService
{
    
    public RetailServiceClient()
    {
    }
    
    public RetailServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public RetailServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public RetailServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public RetailServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public snow.org.retailservice._2014._02._27.OpenSessionResponse OpenSession(snow.org.retailservice._2014._02._27.OpenSessionRequest request)
    {
        return base.Channel.OpenSession(request);
    }
}