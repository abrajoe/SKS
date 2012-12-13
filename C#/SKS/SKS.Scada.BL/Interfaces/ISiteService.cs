using System;
using SKS.Scada.DAL;
using System.Collections.Generic;
namespace SKS.Scada.BL
{
    public interface ISiteService
    {
        Measurement GetLatestSiteState(SKS.Scada.DAL.Site site);
        Site AddSite(Customer custom, string description, double longitude, double latitude);
        List<SKS.Scada.DAL.Site> GetSites(SKS.Scada.DAL.Customer customer);
        Site GetSite(int SiteID);
        void AddMeasurement(Site site, Measurement measurement);
        void AddMeasurement(int siteid, Measurement measurement);
    }
}
