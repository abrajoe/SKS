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
   public class data
    {
        public string siteid, unit;
        public double value;
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISiteService" in both code and config file together.
    [ServiceContract]
    public interface ISiteService
    {
        //System.ServiceModel.Web.dll
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/UploadMeasurement/{siteid}/{unit}", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        void UploadMeasurement(string siteid, string unit, double value);
    }
}
