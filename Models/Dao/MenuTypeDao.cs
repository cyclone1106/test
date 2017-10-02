using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class MenuTypeDao
    {
        JNShopDbContext db = null;
        public MenuTypeDao()
        {
            db = new JNShopDbContext();
        }
        public List<MenuType> ListAll()
        {
            return db.MenuTypes.ToList();
        }
        
    }
}
