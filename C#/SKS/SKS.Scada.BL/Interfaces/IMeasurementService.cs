using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.DAL;

namespace SKS.Scada.BL.Interfaces
{
    interface IMeasurementService
    {
        MeasurementTyp GetMeasurementTyp(string Value);
    }
}
