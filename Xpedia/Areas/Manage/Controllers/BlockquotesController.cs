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
    public class BlockquotesController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/Blockquotes
        public ActionResult Index()
        {
            var blockquotes = db.Blockquotes.Include(b => b.Author);
            return View(blockquotes.ToList());
        }

        // GET: Manage/Blockquotes/Details/5
      

        // GET: Manage/Blockquotes/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname");
            return View();
        }

        // POST: Manage/Blockquotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Background,Image,Title,AuthorID")] Blockquote blockquote,HttpPostedFileBase Image)
        {
            if (Image == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkili seçin");
            }
            else
            {
                blockquote.Image = FileManager.Upload(Image, "~/Uploads/Blockquote");
            }
            if (ModelState.IsValid)
            {
                db.Blockquotes.Add(blockquote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blockquote.AuthorID);
            return View(blockquote);
        }

        // GET: Manage/Blockquotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blockquote blockquote = db.Blockquotes.Find(id);
            if (blockquote == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blockquote.AuthorID);
            return View(blockquote);
        }

        // POST: Manage/Blockquotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Background,Image,Title,AuthorID")] Blockquote blockquote,HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                FileManager.Delete(blockquote.Image, "~/Uploads/Blockquote");
                blockquote.Image = FileManager.Upload(Image, "~/Uploads/Blockquote");
            }
            if (ModelState.IsValid)
            {
                db.Entry(blockquote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Fullname", blockquote.AuthorID);
            return View(blockquote);
        }

        // GET: Manage/Blockquotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blockquote blockquote = db.Blockquotes.Find(id);
            if (blockquote == null)
            {
                return HttpNotFound();
            }
            return View(blockquote);
        }

        // POST: Manage/Blockquotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blockquote blockquote = db.Blockquotes.Find(id);
            db.Blockquotes.Remove(blockquote);
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
