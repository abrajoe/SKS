using System;
namespace SKS.Scada.DAL
{
    public interface IRepository<T> where T:class
    {
        void Add(T EntityObject);
        void CommitChanges();
        void Delete(T EntityObject);
        T GetObjectByID(int id);
        void Update(T EntityObject);
    }
}
