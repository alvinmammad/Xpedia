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
    public class FeaturedDestinationsController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/FeaturedDestinations
        public ActionResult Index()
        {
            return View(db.FeaturedDestinations.ToList());
        }

        // GET: Manage/FeaturedDestinations/Details/5
     

        // GET: Manage/FeaturedDestinations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/FeaturedDestinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Info,Photo,Name")] FeaturedDestination featuredDestination,HttpPostedFileBase Photo)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Image", "Zəhmət olmasa şəkili seçin");
            }
            else
            {
                featuredDestination.Photo = FileManager.Upload(Photo, "~/Uploads/FeaturedDestinations");
            }
            if (ModelState.IsValid)
            {
                db.FeaturedDestinations.Add(featuredDestination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(featuredDestination);
        }

        // GET: Manage/FeaturedDestinations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturedDestination featuredDestination = db.FeaturedDestinations.Find(id);
            if (featuredDestination == null)
            {
                return HttpNotFound();
            }
            return View(featuredDestination);
        }

        // POST: Manage/FeaturedDestinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Info,Photo,Name")] FeaturedDestination featuredDestination,HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                FileManager.Delete(featuredDestination.Photo, "~/Uploads/FeaturedDestinations");
                featuredDestination.Photo= FileManager.Upload(Photo, "~/Uploads/FeaturedDestinations");
            }
            if (ModelState.IsValid)
            {
                db.Entry(featuredDestination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(featuredDestination);
        }

        // GET: Manage/FeaturedDestinations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturedDestination featuredDestination = db.FeaturedDestinations.Find(id);
            if (featuredDestination == null)
            {
                return HttpNotFound();
            }
            return View(featuredDestination);
        }

        // POST: Manage/FeaturedDestinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeaturedDestination featuredDestination = db.FeaturedDestinations.Find(id);
            db.FeaturedDestinations.Remove(featuredDestination);
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
