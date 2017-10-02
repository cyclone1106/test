using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class AboutDao
    {
        JNShopDbContext db = null;
        public AboutDao()
        {
            db = new JNShopDbContext();
        }
        public long Insert(About entity)
        {
            db.Abouts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
       
       

       
    }
}
