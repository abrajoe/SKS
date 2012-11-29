using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.DAL;

namespace SKS.Scada.BL
{
    public class MeasurementService:IMeasurementService
    {
        IRepositoryMeasurmentType repomeasuretyp_;
        private IRepository<Measurement> measurerepo_;
        public MeasurementService(IRepositoryMeasurmentType repomeasuretyp, IRepository<Measurement> measurerepo)
        {
            this.repomeasuretyp_ = repomeasuretyp;
            this.measurerepo_ = measurerepo;
        }

        public DAL.MeasurementTyp GetMeasurementTyp(string Unit)
        {
            MeasurementTyp mtyp = new MeasurementTyp();
            mtyp.Unit = Unit;
            return repomeasuretyp_.GetByUnit(Unit);
        }


        #region IMeasurementService Members


        public Measurement CreateMeasurement(double Value, string Unit)
        {
            Measurement measurement = new Measurement();
            measurement.Value = Value;
            measurement.MeasurementTyp = this.GetMeasurementTyp(Unit);
            measurement.Time = DateTime.Now;
            return measurerepo_.Add(measurement);
        }

        #endregion
    }
}
