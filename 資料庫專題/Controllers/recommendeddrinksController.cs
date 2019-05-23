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
    public class recommendeddrinksController : Controller
    {
        private brtuEntities db = new brtuEntities();

        // GET: recommendeddrinks
        public ActionResult Index()
        {
            var recommendeddrink = db.recommendeddrink.Include(r => r.beveragestore);
            return View(recommendeddrink.ToList());
        }

        // GET: recommendeddrinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recommendeddrink recommendeddrink = db.recommendeddrink.Find(id);
            if (recommendeddrink == null)
            {
                return HttpNotFound();
            }
            return View(recommendeddrink);
        }

        // GET: recommendeddrinks/Create
        public ActionResult Create()
        {
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName");
            return View();
        }

        // POST: recommendeddrinks/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecommendedDrinkId,shopName,Drink,DrinkPrice")] recommendeddrink recommendeddrink)
        {
            if (ModelState.IsValid)
            {
                db.recommendeddrink.Add(recommendeddrink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", recommendeddrink.shopName);
            return View(recommendeddrink);
        }

        // GET: recommendeddrinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recommendeddrink recommendeddrink = db.recommendeddrink.Find(id);
            if (recommendeddrink == null)
            {
                return HttpNotFound();
            }
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", recommendeddrink.shopName);
            return View(recommendeddrink);
        }

        // POST: recommendeddrinks/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecommendedDrinkId,shopName,Drink,DrinkPrice")] recommendeddrink recommendeddrink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recommendeddrink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shopName = new SelectList(db.beveragestore, "shopName", "shopName", recommendeddrink.shopName);
            return View(recommendeddrink);
        }

        // GET: recommendeddrinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recommendeddrink recommendeddrink = db.recommendeddrink.Find(id);
            if (recommendeddrink == null)
            {
                return HttpNotFound();
            }
            return View(recommendeddrink);
        }

        // POST: recommendeddrinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recommendeddrink recommendeddrink = db.recommendeddrink.Find(id);
            db.recommendeddrink.Remove(recommendeddrink);
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
