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
    public class BlogsController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Author).Include(b => b.Category);
            return View(blogs.ToList());
        }

        // GET: Manage/Blogs/Details/5
       

        // GET: Manage/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname");
            ViewBag.CategoryID = new SelectList(db.BlogCategories, "ID", "Name");
            return View();
        }

        // POST: Manage/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Title,Date,Info,Desc,Slug,Photo,AuthorID,CategoryID")] Blog blog,HttpPostedFileBase Photo)
        {
            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkili seçin");
            }
            else
            {
                blog.Photo = FileManager.Upload(Photo, "~/Uploads/Blog");
            }

            if (db.Blogs.Any(b=>b.Slug==blog.Slug))
            {
                ModelState.AddModelError("Slug", "Bu slaq artıq istifadə olunub");
            }
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blog.AuthorID);
            ViewBag.CategoryID = new SelectList(db.BlogCategories, "ID", "Name", blog.CategoryID);
            return View(blog);
        }

        // GET: Manage/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blog.AuthorID);
            ViewBag.CategoryID = new SelectList(db.BlogCategories, "ID", "Name", blog.CategoryID);
            return View(blog);
        }

        // POST: Manage/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Date,Info,Desc,Slug,Photo,AuthorID,CategoryID")] Blog blog,HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                FileManager.Delete(blog.Photo,"~/Uploads/Blog");
                blog.Photo = FileManager.Upload(Photo, "~/Uploads/Blog");
            }
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blog.AuthorID);
            ViewBag.CategoryID = new SelectList(db.BlogCategories, "ID", "Name", blog.CategoryID);
            return View(blog);
        }

        // GET: Manage/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Manage/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
