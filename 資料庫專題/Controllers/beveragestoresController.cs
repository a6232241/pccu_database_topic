using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 資料庫專題.Models;
using 資料庫專題.Repositories;
using 資料庫專題.Services;

namespace 資料庫專題.Controllers
{
    public class beveragestoresController : Controller
    {
        private beveragestoreServices _beveragestoreService = new beveragestoreServices(new beveragestore_repository());
        // GET: beveragestores
        public ActionResult Index()
        {
            return View(_beveragestoreService.GetAllBeveragestores());
        }

        #region HttpGet
        // GET: beveragestores/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: beveragestores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var beveragestore = _beveragestoreService.QueryBeveragestoresById(id);
            if (beveragestore == null)
            {
                return HttpNotFound();
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
            var beveragestore = _beveragestoreService.QueryBeveragestoresById(id);
            if (beveragestore == null)
            {
                return HttpNotFound();
            }
            return View(beveragestore);
        }
        #endregion

        #region HttpPost
        // POST: beveragestores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shopName,shopTotal")] beveragestore beveragestore)
        {
            if (ModelState.IsValid)
            {
                _beveragestoreService.CreateNewBeveragestore(beveragestore);
                return RedirectToAction("Index");
            }

            return View(beveragestore);
        }

        // POST: beveragestores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shopName,shopTotal")] beveragestore beveragestore)
        {
            if (ModelState.IsValid)
            {
                _beveragestoreService.UpdateBeveragestore(beveragestore);
                return RedirectToAction("Index");
            }
            return View(beveragestore);
        }

        // POST: beveragestores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            _beveragestoreService.DeleteBeveragestore(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
