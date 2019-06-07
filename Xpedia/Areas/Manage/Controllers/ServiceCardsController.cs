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
    public class ServiceCardsController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/ServiceCards
        public ActionResult Index()
        {
            return View(db.ServiceCards.ToList());
        }

        // GET: Manage/ServiceCards/Details/5
       

        // GET: Manage/ServiceCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/ServiceCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Info,Icon")] ServiceCard serviceCard)
        {
            if (ModelState.IsValid)
            {
                db.ServiceCards.Add(serviceCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceCard);
        }

        // GET: Manage/ServiceCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCard serviceCard = db.ServiceCards.Find(id);
            if (serviceCard == null)
            {
                return HttpNotFound();
            }
            return View(serviceCard);
        }

        // POST: Manage/ServiceCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Info,Icon")] ServiceCard serviceCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceCard);
        }

        // GET: Manage/ServiceCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCard serviceCard = db.ServiceCards.Find(id);
            if (serviceCard == null)
            {
                return HttpNotFound();
            }
            return View(serviceCard);
        }

        // POST: Manage/ServiceCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceCard serviceCard = db.ServiceCards.Find(id);
            db.ServiceCards.Remove(serviceCard);
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
