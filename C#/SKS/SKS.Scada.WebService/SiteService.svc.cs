using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
namespace SKS.Scada.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventService" in code, svc and config file together.
    public class EventService : ISiteService
    {

        #region ISiteService Members

        public void UploadMeasurement(int SiteID, string Unit, int Value)
        {   
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.LoadConfiguration("UnityConfig");
            unitycontainer.Resolve<ISiteService>();
        }

        #endregion
    }
}
