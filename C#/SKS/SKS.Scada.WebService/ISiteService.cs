using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using SKS.Scada.DAL;

namespace SKS.Scada.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISiteService" in both code and config file together.
    [ServiceContract]
    public interface ISiteService
    {
        //System.ServiceModel.Web.dll
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/", Method="POST")]
        void UploadMeasurement(int SiteID, string Unit, int Value);
    }
}
