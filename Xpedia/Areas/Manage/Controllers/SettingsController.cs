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
    public class SettingsController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/Settings
        public ActionResult Index()
        {
            return View(db.Settings.ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Manage/Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Logo,ChooseUsTitle,ChooseUsDesc,ChooseUsButtonText,ChooseUsPhoto")] Setting setting,HttpPostedFileBase Logo , HttpPostedFileBase ChooseUsPhoto)
        {
            if (Logo != null)
            {
                FileManager.Delete(setting.Logo, "~/Uploads/Settings");
                setting.Logo = FileManager.Upload(Logo, "~/Uploads/Settings");
            }
            if (ChooseUsPhoto != null)
            {
                FileManager.Delete(setting.ChooseUsPhoto, "~/Uploads/Settings");
                setting.ChooseUsPhoto = FileManager.Upload(ChooseUsPhoto, "~/Uploads/Settings");
            }
            if (ModelState.IsValid)
            {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        // GET: Manage/Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Manage/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setting setting = db.Settings.Find(id);
            db.Settings.Remove(setting);
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
