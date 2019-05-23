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
    public class teasController : Controller
    {
        private brtuEntities db = new brtuEntities();

        // GET: teas
        public ActionResult Index()
        {
            var tea = db.tea.Include(t => t.beveragestore);
            return View(tea.ToList());
        }

        // GET: teas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tea tea = db.tea.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        // GET: teas/Create
        public ActionResult Create()
        {
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName");
            return View();
        }

        // POST: teas/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeaId,shopName,Variety,VarietyPrice")] tea tea)
        {
            if (ModelState.IsValid)
            {
                db.tea.Add(tea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", tea.shopName);
            return View(tea);
        }

        // GET: teas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tea tea = db.tea.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", tea.shopName);
            return View(tea);
        }

        // POST: teas/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeaId,shopName,Variety,VarietyPrice")] tea tea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", tea.shopName);
            return View(tea);
        }

        // GET: teas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tea tea = db.tea.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        // POST: teas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tea tea = db.tea.Find(id);
            db.tea.Remove(tea);
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
