using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class SlideDao
    {

        JNShopDbContext db = null;
        public SlideDao()
        {
            db = new JNShopDbContext();
        }
        public long Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Slide entity)
        {
            try
            {
                var slide = db.Slides.Find(entity.ID);
                
                slide.Image = entity.Image;
                slide.Link = entity.Link;
                slide.CreatedDate = entity.CreatedDate;
                slide.CreatedBy = entity.CreatedBy;
                slide.ModifiedDate = entity.ModifiedDate;
                slide.ModifiedBy = entity.ModifiedBy;
                slide.Status = entity.Status;


                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Slide> ListAllPaging( int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            

            return model.OrderByDescending(x => x.Image).ToPagedList(page, pageSize);
        }
        public Slide ViewDetail(int id)
        {
            return db.Slides.Find(id);
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
        public bool ChangeStatus(long id)
        {
            var slide = db.Slides.Find(id);
            slide.Status = !slide.Status;
            db.SaveChanges();
            return slide.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
