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
    public class usergroupsController : Controller
    {
        private brtuEntities db = new brtuEntities();

        // GET: usergroups
        public ActionResult Index()
        {
            var usergroup = db.usergroup.Include(u => u.beveragestore);
            return View(usergroup.ToList());
        }

        // GET: usergroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usergroup usergroup = db.usergroup.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            return View(usergroup);
        }

        // GET: usergroups/Create
        public ActionResult Create()
        {
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName");
            return View();
        }

        // POST: usergroups/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserGroupId,shopName,UGroup,AverageAge")] usergroup usergroup)
        {
            if (ModelState.IsValid)
            {
                db.usergroup.Add(usergroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", usergroup.shopName);
            return View(usergroup);
        }

        // GET: usergroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usergroup usergroup = db.usergroup.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", usergroup.shopName);
            return View(usergroup);
        }

        // POST: usergroups/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserGroupId,shopName,UGroup,AverageAge")] usergroup usergroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usergroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", usergroup.shopName);
            return View(usergroup);
        }

        // GET: usergroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usergroup usergroup = db.usergroup.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            return View(usergroup);
        }

        // POST: usergroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usergroup usergroup = db.usergroup.Find(id);
            db.usergroup.Remove(usergroup);
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
