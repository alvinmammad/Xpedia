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
    public class TestimonialItemsController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/TestimonialItems
        public ActionResult Index()
        {
            var testimonialItems = db.TestimonialItems.Include(t => t.TestimonialRole);
            return View(testimonialItems.ToList());
        }

        // GET: Manage/TestimonialItems/Details/5
       

        // GET: Manage/TestimonialItems/Create
        public ActionResult Create()
        {
            ViewBag.TestimonialRoleID = new SelectList(db.TestimonialRoles, "ID", "Name");
            return View();
        }

        // POST: Manage/TestimonialItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Photo,Review,Fullname,TestimonialRoleID")] TestimonialItem testimonialItem,HttpPostedFileBase Photo)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkili seçin");
            }
            else
            {
                testimonialItem.Photo = FileManager.Upload(Photo, "~/Uploads/Testimonial");
            }
            if (ModelState.IsValid)
            {
                db.TestimonialItems.Add(testimonialItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestimonialRoleID = new SelectList(db.TestimonialRoles, "ID", "Name", testimonialItem.TestimonialRoleID);
            return View(testimonialItem);
        }

        // GET: Manage/TestimonialItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestimonialItem testimonialItem = db.TestimonialItems.Find(id);
            if (testimonialItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestimonialRoleID = new SelectList(db.TestimonialRoles, "ID", "Name", testimonialItem.TestimonialRoleID);
            return View(testimonialItem);
        }

        // POST: Manage/TestimonialItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Photo,Review,Fullname,TestimonialRoleID")] TestimonialItem testimonialItem,HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                FileManager.Delete(testimonialItem.Photo, "~/Uploads/Testimonial");
                testimonialItem.Photo = FileManager.Upload(Photo, "~/Uploads/Testimonial");
            }
            if (ModelState.IsValid)
            {
                db.Entry(testimonialItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestimonialRoleID = new SelectList(db.TestimonialRoles, "ID", "Name", testimonialItem.TestimonialRoleID);
            return View(testimonialItem);
        }

        // GET: Manage/TestimonialItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestimonialItem testimonialItem = db.TestimonialItems.Find(id);
            if (testimonialItem == null)
            {
                return HttpNotFound();
            }
            return View(testimonialItem);
        }

        // POST: Manage/TestimonialItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestimonialItem testimonialItem = db.TestimonialItems.Find(id);
            db.TestimonialItems.Remove(testimonialItem);
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
