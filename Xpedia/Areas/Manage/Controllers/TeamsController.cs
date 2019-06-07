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
    public class TeamsController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/Teams
        public ActionResult Index()
        {
            var teams = db.Teams.Include(t => t.TeamCategory);
            return View(teams.ToList());
        }

        // GET: Manage/Teams/Details/5
    

        // GET: Manage/Teams/Create
        public ActionResult Create()
        {
            ViewBag.TeamCategoryID = new SelectList(db.TeamCategories, "ID", "Name");
            return View();
        }

        // POST: Manage/Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Photo,Fullname,TeamCategoryID")] Team team,HttpPostedFileBase Photo)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkili seçin");
            }
            else
            {
                team.Photo = FileManager.Upload(Photo, "~/Uploads/Team");
            }
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamCategoryID = new SelectList(db.TeamCategories, "ID", "Name", team.TeamCategoryID);
            return View(team);
        }

        // GET: Manage/Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamCategoryID = new SelectList(db.TeamCategories, "ID", "Name", team.TeamCategoryID);
            return View(team);
        }

        // POST: Manage/Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Photo,Fullname,TeamCategoryID")] Team team,HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                FileManager.Delete(team.Photo, "~/Uploads/Team");
                team.Photo= FileManager.Upload(Photo, "~/Uploads/Team");
            }
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamCategoryID = new SelectList(db.TeamCategories, "ID", "Name", team.TeamCategoryID);
            return View(team);
        }

        // GET: Manage/Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Manage/Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
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
