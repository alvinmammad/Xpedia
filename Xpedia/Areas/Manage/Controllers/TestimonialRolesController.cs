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

namespace Xpedia.Areas.Manage.Controllers
{
    public class TestimonialRolesController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/TestimonialRoles
        public ActionResult Index()
        {
            return View(db.TestimonialRoles.ToList());
        }

        // GET: Manage/TestimonialRoles/Details/5
     
        // GET: Manage/TestimonialRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/TestimonialRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TestimonialRole testimonialRole)
        {
            if (ModelState.IsValid)
            {
                db.TestimonialRoles.Add(testimonialRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testimonialRole);
        }

        // GET: Manage/TestimonialRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestimonialRole testimonialRole = db.TestimonialRoles.Find(id);
            if (testimonialRole == null)
            {
                return HttpNotFound();
            }
            return View(testimonialRole);
        }

        // POST: Manage/TestimonialRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TestimonialRole testimonialRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testimonialRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonialRole);
        }

        // GET: Manage/TestimonialRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestimonialRole testimonialRole = db.TestimonialRoles.Find(id);
            if (testimonialRole == null)
            {
                return HttpNotFound();
            }
            return View(testimonialRole);
        }

        // POST: Manage/TestimonialRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestimonialRole testimonialRole = db.TestimonialRoles.Find(id);
            db.TestimonialRoles.Remove(testimonialRole);
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
