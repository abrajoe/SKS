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
    class CustomerService : SKS.Scada.BL.ICustomerService
    {
        ILog logger_ = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IRepository<Customer> repocustomer_;
        public CustomerService(IRepository<Customer> repocustomer)
        {
            this.repocustomer_ = repocustomer;
        }

        public Customer AddCustomer(string firstname, string email, string lastname, string password, string username, Technician technician)
        {
            Customer customer = new Customer();
            customer.Person = new Person()
            {
                Firstname = firstname,
                Email = email,
                Lastname = lastname,
                Password = password,
                Username = username
            };
            customer.Technician = technician;
            customer = repocustomer_.Add(customer);
            repocustomer_.CommitChanges();
            return customer;
        }
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
