using System;
namespace SKS.Scada.DAL
{
    public interface IRepositoryMeasurmentType
    {
        MeasurementTyp GetByUnit(string Unit);
    }
}
