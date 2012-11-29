using System;
using System.Collections.Generic;
namespace SKS.Scada.BL
{
    public interface ICustomerService
    {
        List<SKS.Scada.DAL.Customer> GetCustomers(SKS.Scada.DAL.Technician technician);
    }
}
