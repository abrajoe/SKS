using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SKS.Scada.BL;

namespace SKS.Scada.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventService" in code, svc and config file together.
    public class SiteService : ISiteService
    {
        
        #region ISiteService Members

        public void UploadMeasurement(string siteid, string unit, double value)
        {
            
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.LoadConfiguration("UnityContainer");
            SKS.Scada.BL.ISiteService siteserv = unitycontainer.Resolve<SKS.Scada.BL.ISiteService>();
            SKS.Scada.BL.IMeasurementService measureserv = unitycontainer.Resolve<SKS.Scada.BL.IMeasurementService>();
            siteserv.AddMeasurement(Convert.ToInt32(siteid), measureserv.CreateMeasurement(value, unit));
        }

        #endregion
    }
}
