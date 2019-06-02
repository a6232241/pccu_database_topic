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
    public class recommendeddrinksController : Controller
    {
        private recommendeddrinkServices _recommendeddrinkService = new recommendeddrinkServices(new recommendeddrink_repository());

        // GET: recommendeddrinks
        public ActionResult Index()
        {
            return View(_recommendeddrinkService.GetAllRecommendedrink());
        }

        #region HttpGet
        // GET: recommendeddrinks/Create
        public ActionResult Create()
        {
            ViewBag.shopName = _recommendeddrinkService.SearchBeveragestore();
            return View();
        }

        // GET: recommendeddrinks/Edit/5
        public ActionResult Edit(int id)
        {
            recommendeddrink recommendeddrink = _recommendeddrinkService.QueryRecommendeddrink(id);
            if (recommendeddrink == null)
            {
                return HttpNotFound();
            }
            ViewBag.shopName = _recommendeddrinkService.SearchBeveragestore();
            return View(recommendeddrink);
        }

        // GET: recommendeddrinks/Delete/5
        public ActionResult Delete(int id)
        {
            recommendeddrink recommendeddrink = _recommendeddrinkService.QueryRecommendeddrink(id);
            if (recommendeddrink == null)
            {
                return HttpNotFound();
            }
            return View(recommendeddrink);
        }

        #endregion

        #region HttpPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecommendedDrinkId,shopName,Drink,DrinkPrice")] recommendeddrink recommendeddrink)
        {
            if (ModelState.IsValid)
            {
                _recommendeddrinkService.CreateNewRecommendeddrink(recommendeddrink);
                return RedirectToAction("Index");
            }

            ViewBag.shopName = _recommendeddrinkService.SearchBeveragestore();
            return View(recommendeddrink);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecommendedDrinkId,shopName,Drink,DrinkPrice")] recommendeddrink recommendeddrink)
        {
            if (ModelState.IsValid)
            {
                _recommendeddrinkService.UpdateRecommendeddrink(recommendeddrink);
                return RedirectToAction("Index");
            }
            ViewBag.shopName = _recommendeddrinkService.SearchBeveragestore();
            return View(recommendeddrink);
        }

        // POST: recommendeddrinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _recommendeddrinkService.DeleteRecommendedrink(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
