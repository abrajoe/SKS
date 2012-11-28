using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.DAL;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using log4net;

namespace SKS.Scada.BL
{
    class StatisticsService : IStatisticsService
    {
        ILog logger_ = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ValidatorFactory valFactory;
        IRepository<Measurement> measurerepo_;
        public StatisticsService(IRepository<Measurement> MeasurementRepository)
        {
            valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            measurerepo_ = MeasurementRepository;
        }
        public List<Measurement> GetCustomerStatistics(Customer customer, DateTime StartDate, DateTime EndDate)
        {
            Validator<Customer> validator = valFactory.CreateValidator<Customer>();
            ValidationResults valResults = validator.Validate(customer);
            if (!valResults.IsValid)
            {
                logger_.Error("Validation Error");
                throw new ValidationException();
            }
            
            return measurerepo_.GetAll().Where(x => x.Site.Customer == customer && x.Time >= StartDate 
                && x.Time <= EndDate ).ToList();
        }
    }
}
