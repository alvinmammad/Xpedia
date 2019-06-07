using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xpedia.DAL;
using Xpedia.Models;
using Xpedia.Areas.Manage.Filter;
using Xpedia.Areas.Manage.Helpers;


namespace Xpedia.Areas.Manage.Controllers
{
    public class AboutStoriesController : Controller
    {
        private XpediaContext db = new XpediaContext();

        public ActionResult Index()
        {
            return View(db.AboutStories.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Title,Desc,Photo,Signature")] AboutStory aboutStory,HttpPostedFileBase Photo, HttpPostedFileBase Signature)
        {
            if (Photo == null )
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkili seçin");
            }
            else
            {
                aboutStory.Photo = FileManager.Upload(Photo, "~/Uploads/About");
            }

            if (Signature == null)
            {
                ModelState.AddModelError("Signature", "Zəhmət olmasa imza seçin");
            }
            else
            {
                aboutStory.Signature = FileManager.Upload(Signature, "~/Uploads/About");
            }

            if (ModelState.IsValid)
            {
                db.AboutStories.Add(aboutStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutStory);
        }

        // GET: Manage/AboutStories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutStory aboutStory = db.AboutStories.Find(id);
            if (aboutStory == null)
            {
                return HttpNotFound();
            }
            return View(aboutStory);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit([Bind(Include = "ID,Title,Desc,Photo,Signature")] AboutStory aboutStory,HttpPostedFileBase Photo , HttpPostedFileBase Signature)
        {
            if (Photo != null)
            {
                FileManager.Delete(aboutStory.Photo, "~/Uploads/About");
                aboutStory.Photo = FileManager.Upload(Photo, "~/Uploads/About");
            }

            if (Signature != null)
            {
                FileManager.Delete(aboutStory.Signature, "~/Uploads/About");
                aboutStory.Signature = FileManager.Upload(Signature, "~/Uploads/About");
            }

            if (ModelState.IsValid)
            {
                db.Entry(aboutStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutStory);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutStory aboutStory = db.AboutStories.Find(id);
            if (aboutStory == null)
            {
                return HttpNotFound();
            }
            return View(aboutStory);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutStory aboutStory = db.AboutStories.Find(id);
            db.AboutStories.Remove(aboutStory);
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
