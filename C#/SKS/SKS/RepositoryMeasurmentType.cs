using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKS.Scada.DAL
{
    class RepositoryMeasurmentType:DBRepository<MeasurementTyp>, SKS.Scada.DAL.IRepositoryMeasurmentType
    {
        public MeasurementTyp GetByUnit(string Unit)
        {
            var measurementtyp =
                from x in dbset_
                where x.Unit == Unit
                select x;
            return measurementtyp.First();
        }
    }
}
