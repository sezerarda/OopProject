using DataLayer.Abstract;
using DataLayer.Concretes.Repository;
using DataLayer.DataBase;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concretes.EntityFramework
{
    public class EfNewsDal : GenericRepository<News>, INewsDal
    {
        public void NewsStatusToFalse(int id)
        {
            using var context = new ProjectContext();
            News n = context.Newses.Find(id);
            n.Status = false;
            context.SaveChanges();
        }

        public void NewsStatusToTrue(int id)
        {
            using var context = new ProjectContext();
            News n = context.Newses.Find(id);
            n.Status = true;
            context.SaveChanges();  
        }
    }
}
