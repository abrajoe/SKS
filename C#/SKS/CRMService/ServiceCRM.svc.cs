using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SKS.Scada.DAL;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace SKS.Scada.CRMService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ServiceCRM : IServiceCRM
    {
        public void AddSite(Customer custom, string description, double longitude, double latitude)
        {

            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.LoadConfiguration("UnityContainer");

            SKS.Scada.BL.ISiteService siteserv = unitycontainer.Resolve<SKS.Scada.BL.ISiteService>();
            siteserv.AddSite(custom, description, longitude, latitude);
            
        }        

        public Customer AddCustomer(string firstname, string email, string lastname, 
            string password, string username, Technician technician)
        {
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.LoadConfiguration("UnityContainer");
            SKS.Scada.BL.ICustomerService custserv = unitycontainer.Resolve<SKS.Scada.BL.ICustomerService>();
            return custserv.AddCustomer(firstname, email, lastname,
             password, username, technician);
            
        }

        
    }
}
