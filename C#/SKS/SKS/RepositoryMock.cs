using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKS.Scada.DAL
{
    public class RepositoryMock<T>:IRepository<T> where T:class
    {
        List<T> list_;

        public RepositoryMock()
        {
            list_ = new List<T>();
        }

        #region IRepository<T> Members

        public void Add(T EntityObject)
        {
            list_.Add(EntityObject);
        }

        public void CommitChanges()
        {
            throw new NotImplementedException();
        }

        public void Delete(T EntityObject)
        {
            list_.Remove(EntityObject);
        }

        public T GetObjectByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return list_;
        }

        public void Update(T EntityObject)
        {
            T elem = list_.Where(x => x == EntityObject).Single();
            elem = EntityObject;
        }
        #endregion
    }
}
