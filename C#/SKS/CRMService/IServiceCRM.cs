using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SKS.Scada.DAL;

namespace SKS.Scada.CRMService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceCRM
    {
        [OperationContract]
        void AddSite(Customer custom, string description, double longitude, double latitude);

        [OperationContract]
        Customer AddCustomer(string firstname, string email, string lastname, string password, string username, Technician technician);

        // TODO: Add your service operations here
    }


}
