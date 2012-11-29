using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;

namespace SKS.Scada.DAL
{
    public class DBRepository<T> : IRepository<T> where T:class
    {
        SKSEntities sksent_;
        protected DbSet<T> dbset_;
        public DBRepository()
        {
            sksent_ = new SKSEntities();
            dbset_ = sksent_.Set<T>();
        }
        #region IRepository<T> Members

        public T Add(T EntityObject)
        {
            return dbset_.Add(EntityObject);
        }

        public void CommitChanges()
        {
            sksent_.SaveChanges();
        }

        public void Delete(T EntityObject)
        {
            dbset_.Remove(EntityObject);
        }

        public T GetObjectByID(int id)
        {
            return dbset_.Find(id);
        }

        public void Update(T EntityObject)
        {
            dbset_.Attach(EntityObject);
            sksent_.Entry<T>(EntityObject).State = EntityState.Modified;
        }
        public List<T> GetAll()
        {
            return dbset_.ToList();
        }

        #endregion
    }
}
