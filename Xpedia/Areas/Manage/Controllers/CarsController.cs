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
    public class CarsController : Controller
    {
        private XpediaContext db = new XpediaContext();

        // GET: Manage/Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.CarModel).Include(c => c.Location);
            return View(cars.ToList());
        }

        // GET: Manage/Cars/Details/5
       
        // GET: Manage/Cars/Create
        public ActionResult Create()
        {
            ViewBag.CarModelID = new SelectList(db.CarModels, "ID", "Name");
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name");
            return View();
        }

        // POST: Manage/Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PricePerDay,Information,TwoAir,Fuel,Transmission,CarType,Year,EngineCapacity,EnginePower,IsRented,Discount,SeatCount,Image,CarModelID,LocationID")] Car car,HttpPostedFileBase Image)
        {
            if (Image == null)
            {
                ModelState.AddModelError("Image", "Zəhmət olmasa şəkili seçin");
            }
            else
            {
                car.Image = FileManager.Upload(Image,"~/Uploads/Car");
            }
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarModelID = new SelectList(db.CarModels, "ID", "Name", car.CarModelID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name", car.LocationID);
            return View(car);
        }

        // GET: Manage/Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarModelID = new SelectList(db.CarModels, "ID", "Name", car.CarModelID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name", car.LocationID);
            return View(car);
        }

        // POST: Manage/Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PricePerDay,Information,TwoAir,Fuel,Transmission,CarType,Year,EngineCapacity,EnginePower,IsRented,Discount,SeatCount,Image,CarModelID,LocationID")] Car car,HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                FileManager.Delete(car.Image,"~/Uploads/Car");
                car.Image= FileManager.Upload(Image,"~/Uploads/Car");
            }

            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarModelID = new SelectList(db.CarModels, "ID", "Name", car.CarModelID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name", car.LocationID);
            return View(car);
        }

        // GET: Manage/Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Manage/Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
