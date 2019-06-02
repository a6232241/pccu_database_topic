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
    public class beveragestore_repository : IRepository<beveragestore>
    {
        private brtuEntities db = new brtuEntities();
        public IEnumerable<beveragestore> GetAll()
        {
            return db.beveragestore.ToList();
        }

        public beveragestore GetSingle(int id)
        {
            beveragestore beveragestore = db.beveragestore.Find(id);
            return beveragestore;
        }

        public beveragestore GetSingle(string id)
        {
            beveragestore beveragestore = db.beveragestore.Find(id);
            return beveragestore;
        }

        public void Update(beveragestore entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(beveragestore entity)
        {
            db.beveragestore.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            beveragestore beveragestore = db.beveragestore.Find(id);
            db.beveragestore.Remove(beveragestore);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            beveragestore beveragestore = db.beveragestore.Find(id);
            db.beveragestore.Remove(beveragestore);
            db.SaveChanges();
        }

        public dynamic SearchPrimaryKey()
        {
            return new SelectList(db.beveragestore, "shopName", "shopName");
        }
    }
}