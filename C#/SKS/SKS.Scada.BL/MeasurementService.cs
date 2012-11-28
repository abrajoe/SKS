using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.DAL;

namespace SKS.Scada.BL.Interfaces
{
    class MeasurementService:IMeasurementService
    {

        IRepositoryMeasurmentType repomeasuretyp_;
        public MeasurementService(IRepositoryMeasurmentType repomeasuretyp)
        {
            this.repomeasuretyp_ = repomeasuretyp;
        }

        public DAL.MeasurementTyp GetMeasurementTyp(string Unit)
        {
            MeasurementTyp mtyp = new MeasurementTyp();
            mtyp.Unit = Unit;
            return null;
        }

    }
}
