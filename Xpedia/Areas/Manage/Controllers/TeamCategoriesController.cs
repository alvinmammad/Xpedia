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
    public class TeamCategoriesController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/TeamCategories
        public ActionResult Index()
        {
            return View(db.TeamCategories.ToList());
        }

        // GET: Manage/TeamCategories/Details/5
     

        // GET: Manage/TeamCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/TeamCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TeamCategory teamCategory)
        {
            if (ModelState.IsValid)
            {
                db.TeamCategories.Add(teamCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamCategory);
        }

        // GET: Manage/TeamCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamCategory teamCategory = db.TeamCategories.Find(id);
            if (teamCategory == null)
            {
                return HttpNotFound();
            }
            return View(teamCategory);
        }

        // POST: Manage/TeamCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TeamCategory teamCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamCategory);
        }

        // GET: Manage/TeamCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamCategory teamCategory = db.TeamCategories.Find(id);
            if (teamCategory == null)
            {
                return HttpNotFound();
            }
            return View(teamCategory);
        }

        // POST: Manage/TeamCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamCategory teamCategory = db.TeamCategories.Find(id);
            db.TeamCategories.Remove(teamCategory);
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
