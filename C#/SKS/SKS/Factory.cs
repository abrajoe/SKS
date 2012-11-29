using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKS.Scada.DAL
{
    public class Factory<T> where T:class
    {
        
        public static IRepository<T> GetRepo()
        {   
            //return new RepositoryMock<T>();
            return new DBRepository<T>();
        }
    }
}
