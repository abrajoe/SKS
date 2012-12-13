using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.ConsoleCRM.ServiceCRM;
//using SKS.Scada.DAL;

namespace SKS.Scada.ConsoleCRM
{
    class Program
    {
        static void Main(string[] args)
        {
         //   DBRepository<Technician> techrepo = new DBRepository<Technician>();
            
            ServiceCRMClient client = new ServiceCRMClient();
            Technician technician = new Technician();
            technician.TechnicianID = 1;
            client.AddCustomer("firstname", "email", "lastname", "password","username", technician);

        }
    }
}
