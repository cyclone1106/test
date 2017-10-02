using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class CategoryDao
    {
        JNShopDbContext db = null;
        public CategoryDao()
        {
            db = new JNShopDbContext();
        }
        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.ID;
        }
        public bool Update(Category entity)
        {
            try
            {
                var category = db.Categories.Find(entity.ID);
                category.Name = entity.Name;
                category.MetaTitle = entity.MetaTitle;
                category.ParentID = entity.ParentID;
                category.DisplayOrder = entity.DisplayOrder;
                category.SeoTitle = entity.SeoTitle;
                category.CreatedDate = entity.CreatedDate;
                category.CreatedBy = entity.CreatedBy;
                category.ModifiedDate = entity.ModifiedDate;
                category.ModifiedBy = entity.ModifiedBy;
                category.MetaKeywords = entity.MetaKeywords;
                category.MetaDescriptions = entity.MetaDescriptions;
                category.Status = entity.Status;
                category.ShowOnHome = entity.ShowOnHome;
                category.Language = entity.Language;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
        
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }


        public bool ChangeStatus(long id)
        {
            var category = db.Categories.Find(id);
            category.Status = !category.Status;
            db.SaveChanges();
            return category.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
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
