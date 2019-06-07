using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xpedia.Areas.Manage.Helpers;
using Xpedia.DAL;
using Xpedia.Models;

namespace Xpedia.Areas.Manage.Controllers
{
    public class LogoSlidersController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/LogoSliders
        public ActionResult Index()
        {
            return View(db.LogoSliders.ToList());
        }

        // GET: Manage/LogoSliders/Details/5
      

        // GET: Manage/LogoSliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/LogoSliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Logo")] LogoSlider logoSlider,HttpPostedFileBase Logo)
        {
            if (Logo == null)
            {
                ModelState.AddModelError("Logo", "Zəhmət olmasa şəkili seçin");
            }
            else
            {
                logoSlider.Logo = FileManager.Upload(Logo, "~/Uploads/CarLogos");
            }
            if (ModelState.IsValid)
            {
                db.LogoSliders.Add(logoSlider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logoSlider);
        }

        // GET: Manage/LogoSliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogoSlider logoSlider = db.LogoSliders.Find(id);
            if (logoSlider == null)
            {
                return HttpNotFound();
            }
            return View(logoSlider);
        }

        // POST: Manage/LogoSliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Logo")] LogoSlider logoSlider,HttpPostedFileBase Logo)
        {
            if (Logo != null)
            {
                FileManager.Delete(logoSlider.Logo, "~/Uploads/CarLogos");
                logoSlider.Logo = FileManager.Upload(Logo, "~/Uploads/CarLogos");
            }
            if (ModelState.IsValid)
            {
                db.Entry(logoSlider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logoSlider);
        }

        // GET: Manage/LogoSliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogoSlider logoSlider = db.LogoSliders.Find(id);
            if (logoSlider == null)
            {
                return HttpNotFound();
            }
            return View(logoSlider);
        }

        // POST: Manage/LogoSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogoSlider logoSlider = db.LogoSliders.Find(id);
            db.LogoSliders.Remove(logoSlider);
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
