using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        OnlineShopDbContext db = null;
        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Content> ListAll()
        {
            return db.Contents.ToList();
        }
        public List<Content> ListAllActive()
        {
            return db.Contents.Where(x => x.Status == true).ToList();
        }

        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Content entity)
        {
            try
            {
                var content = db.Contents.Find(entity.ID);
                content.Name = entity.Name;
                content.MetaTitle = entity.MetaTitle;
                content.Description = entity.Description;
                content.Image = entity.Image;
                content.CategoryID = entity.CategoryID;
                content.detail = entity.detail;
                content.Warranty = entity.Warranty;
                content.ModifiedDate = DateTime.Now;
                content.MetaKeywords = entity.MetaKeywords;
                content.MetaDescription = entity.MetaDescription;
                content.Status = entity.Status;
                content.TopHot = entity.TopHot;
                content.Tags = entity.Tags;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
        public bool Delete(long id)
        {
            try
            {
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Content ViewDetail(long id)
        {
            return db.Contents.Find(id);
        }
        public Content GetByID(long id)
        {
            return db.Contents.SingleOrDefault(x=> x.ID == id);
        }
        
    }
}
