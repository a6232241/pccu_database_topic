using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 資料庫專題.Models;

namespace 資料庫專題.Controllers
{
    public class beveragestoresController : Controller
    {
        private brtuEntities db = new brtuEntities();

        // GET: beveragestores
        public ActionResult Index()
        {
            return View(db.beveragestore.ToList());
        }

        // GET: beveragestores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beveragestore beveragestore = db.beveragestore.Find(id);
            if (beveragestore == null)
            {
                return HttpNotFound();
            }
            return View(beveragestore);
        }

        // GET: beveragestores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: beveragestores/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shopName,shopTotal")] beveragestore beveragestore)
        {
            if (ModelState.IsValid)
            {
                db.beveragestore.Add(beveragestore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beveragestore);
        }

        // GET: beveragestores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beveragestore beveragestore = db.beveragestore.Find(id);
            if (beveragestore == null)
            {
                return HttpNotFound();
            }
            return View(beveragestore);
        }

        // POST: beveragestores/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shopName,shopTotal")] beveragestore beveragestore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beveragestore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beveragestore);
        }

        // GET: beveragestores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beveragestore beveragestore = db.beveragestore.Find(id);
            if (beveragestore == null)
            {
                return HttpNotFound();
            }
            return View(beveragestore);
        }

        // POST: beveragestores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            beveragestore beveragestore = db.beveragestore.Find(id);
            db.beveragestore.Remove(beveragestore);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
