using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class FooterDao
    {
        JNShopDbContext db = null;
        public FooterDao()
        {
            db = new JNShopDbContext();
        }

        public bool Update(Footer entity)
        {
            try
            {
                var footer = db.Footers.Find(entity.ID);
                footer.ID = entity.ID;
                footer.Content = entity.Content;
                footer.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }
        public Footer ViewDetail(int id)
        {
            return db.Footers.Find(id);
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }


    }
}
