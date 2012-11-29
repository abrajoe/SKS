using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.DAL;
using SKS.Scada.BL;

namespace SKS.Scada.BL
{
    
    public interface IMeasurementService
    {
        MeasurementTyp GetMeasurementTyp(string Value);
        Measurement CreateMeasurement(double Value, string Unit);
    }
}
