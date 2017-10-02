using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class ProductCategoryDao
    {
        JNShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new JNShopDbContext();
        }
        public long Insert(ProductCategory productcategory)
        {
            db.ProductCategories.Add(productcategory);
            db.SaveChanges();
            return productcategory.ID;
        }
        public bool Update(ProductCategory entity)
        {
            try
            {
                var productcategory = db.ProductCategories.Find(entity.ID);
                productcategory.Name = entity.Name; 
                productcategory.MetaTitle = entity.MetaTitle;
                productcategory.ParentID = entity.ParentID;
                productcategory.DisplayOrder = entity.DisplayOrder;
                productcategory.SeoTitle = entity.SeoTitle;
                productcategory.CreatedDate = entity.CreatedDate;
                productcategory.CreatedBy = entity.CreatedBy;
                productcategory.ModifiedDate = entity.ModifiedDate;
                productcategory.ModifiedBy = entity.ModifiedBy;
                productcategory.MetaKeywords = entity.MetaKeywords;
                productcategory.MetaDescriptions = entity.MetaDescriptions;
                productcategory.Status = entity.Status;
                productcategory.ShowOnHome = entity.ShowOnHome;
               
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }


        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }


        public bool ChangeStatus(long id)
        {
            var productcategory = db.ProductCategories.Find(id);
            productcategory.Status = !productcategory.Status;
            db.SaveChanges();
            return productcategory.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var productcategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productcategory);
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
