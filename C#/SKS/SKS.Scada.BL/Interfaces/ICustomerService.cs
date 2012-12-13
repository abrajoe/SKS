using System;
using System.Collections.Generic;
using SKS.Scada.DAL;
namespace SKS.Scada.BL
{
    public interface ICustomerService
    {
        List<SKS.Scada.DAL.Customer> GetCustomers(SKS.Scada.DAL.Technician technician);
        Customer AddCustomer(string firstname, string email, string lastname, string password, string username, Technician technician);
    }
}
