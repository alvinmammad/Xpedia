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
    public class OrdersController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Car).Include(o => o.User);
            return View(orders.ToList());
        }

        // GET: Manage/Orders/Details/5
        
       

        // GET: Manage/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Cars, "ID", "Information", order.CarID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", order.UserID);
            return View(order);
        }

        // POST: Manage/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderNumber,PickUpLocation,DropOffLocation,PickUpDate,DropOffDate,IsConfirmed,UserID,CarID,DoFinish")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Cars, "ID", "Information", order.CarID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", order.UserID);
            return View(order);
        }

        // GET: Manage/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Manage/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
