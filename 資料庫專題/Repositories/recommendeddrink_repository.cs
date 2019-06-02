using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using 資料庫專題.Models;
using 資料庫專題.Interface;
using System.Web.Mvc;

namespace 資料庫專題.Repositories
{
    public class recommendeddrink_repository: IRepository<recommendeddrink>
    {
        private brtuEntities db = new brtuEntities();

        public IEnumerable<recommendeddrink> GetAll()
        {
            var recommendeddrink = db.recommendeddrink.Include(r => r.beveragestore);
            return db.recommendeddrink.ToList();
        }

        public recommendeddrink GetSingle(int id)
        {
            recommendeddrink recommendeddrink = db.recommendeddrink.Find(id);
            return recommendeddrink;
        }

        public recommendeddrink GetSingle(string id)
        {
            recommendeddrink recommendeddrink = db.recommendeddrink.Find(id);
            return recommendeddrink;
        }

        public void Update(recommendeddrink entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(recommendeddrink entity)
        {
            db.recommendeddrink.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            recommendeddrink recommendeddrink = db.recommendeddrink.Find(id);
            db.recommendeddrink.Remove(recommendeddrink);
            db.SaveChanges();
        }

        //取值不包含字串，因此不加入實作
        public void Delete(string id) { }

        public dynamic SearchPrimaryKey()
        {
            return new SelectList(db.beveragestore, "shopName", "shopName");
        }
    }
}