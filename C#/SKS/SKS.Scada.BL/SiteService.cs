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
    class SiteService : ISiteService
    {
        ILog logger_ = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ValidatorFactory valFactory;
        IRepository<Site> reposite_;
        IRepository<Measurement> repomeasurement_;
        public SiteService(IRepository<Site> reposite, IRepository<Measurement> repomeasurement)
        {
            valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            this.reposite_ = reposite;
        }
        public Measurement GetLatestSiteState(Site site)
        {
            Validator<Site> validator = valFactory.CreateValidator<Site>();
            ValidationResults valResults = validator.Validate(site);
            if (!valResults.IsValid)
            {
                logger_.Error("Validation Error");
                throw new ValidationException();
            }
            logger_.Info("Returned latest Site Measurement");
            return site.Measurements.OrderByDescending(x => x.Time).First();
        }

        public List<Site> GetSites(Customer customer)
        {
            Validator<Customer> validator = valFactory.CreateValidator<Customer>();
            ValidationResults valResults = validator.Validate(customer);
            if (!valResults.IsValid)
            {
                logger_.Error("Validation Error");
                throw new ValidationException();
            }
            logger_.Info("Returned customers site");
            return customer.Sites.ToList();
        }

        #region ISiteService Members


        public Site GetSite(int SiteID)
        {
            Site site = reposite_.GetObjectByID(SiteID);
            return site;
        }

        public void AddMeasurement(Site site, Measurement measurement)
        {
            repomeasurement_.Add(measurement);
            site.Measurements.Add(measurement);
            repomeasurement_.CommitChanges();
            reposite_.CommitChanges();
        }

        public void AddMeasurement(int SiteID, Measurement measurement)
        { 

        }
        #endregion
    }
}
