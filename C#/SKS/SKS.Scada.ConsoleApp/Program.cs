using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.DAL;

namespace SKS.Scada.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Person> repo = Factory<Person>.Get();
            //Person p = new Person()
            //{
            //    Email = "max.mutz@gmail.com",
            //    Firstname = "Max",
            //    Lastname = "Mutz",
            //    Password = "123456",
            //    Username = "maxmutz"
            //};
            //repo.Add(p);
            //repo.CommitChanges();
            
            Person x = repo.GetObjectByID(1);
            x.Firstname = "huhu";
            repo.Update(x);
            repo.CommitChanges();
        }
    }
}
