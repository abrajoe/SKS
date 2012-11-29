using System;
using System.Collections.Generic;
namespace SKS.Scada.DAL
{
    public interface IRepository<T> where T:class
    {
        T Add(T EntityObject);
        void CommitChanges();
        void Delete(T EntityObject);
        T GetObjectByID(int id);
        List<T> GetAll();
        void Update(T EntityObject);
    }
    
}
