using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.DAL;
using log4net;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;


namespace SKS.Scada.BL
{
    class CustomerService
    {
        ILog logger_ = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<Customer> GetCustomers(Technician technician)
        {
            ValidatorFactory valFactory
               = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<Technician> validator = valFactory.CreateValidator<Technician>();
            ValidationResults valResults = validator.Validate(technician);
            if (!valResults.IsValid)
            {
                logger_.Error("Validation Error");
                throw new ValidationException();
            }
            logger_.Info("Returned Customer from technician");
            return technician.Customers.ToList();
        }
    }
}
