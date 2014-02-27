using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Snow.Web.RetailService
{
    [ServiceContract(Namespace="http://snow.org/retailservice/2014/02/27", Name="RetailService")]
    public interface IRetailService
    {
        [OperationContract(Name="OpenSession")]
        OpenSessionResponse OpenSession(OpenSessionRequest request);
    }
}
