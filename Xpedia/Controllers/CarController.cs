using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpedia.Models;
using Xpedia.ViewModel;
using System.Data.Entity;
using Newtonsoft.Json;

namespace Xpedia.Controllers
{
    public class CarController : BaseController
    {
        VmCar model = new VmCar();
        #region Searched Cars

        public ActionResult Car(string searchedCars ,int page = 1)
        {
           

            if (searchedCars==null)
            {
                model.TotalPage = Convert.ToInt32(Math.Ceiling(_context.Cars.Count() / 12.0));
                if (page < 1 || page > model.TotalPage)
                {
                    return HttpNotFound();
                }
                model.Page = page;
                model.Cars = _context.Cars.Include(m => m.CarModel).Include(m => m.CarModel.Brand).OrderBy(c => c.CarModel.Name).Skip((page-1)*12).Take(12).ToList();
                model.CarModels = _context.CarModels.ToList();
                model.Brands = _context.Brands.ToList();
                model.Cars.
                Skip((page - 1) * 12).
                Take(12).
                ToList();
                model.Page = page;
                return View("car", model);
            }
            
            VmSearchingCar allCars = JsonConvert.DeserializeObject<VmSearchingCar>(searchedCars);
            List<Car> cars = _context.Cars.Include(m => m.CarModel).Include(m => m.CarModel.Brand).Where(c => c.LocationID == allCars.PickUpLocation && c.IsRented == false).ToList();
            List<Order> orders = _context.Orders.ToList();
            var dublicateCars = from c in cars
                                join o in orders
                                on c.ID equals o.CarID
                                select o;
            foreach (var c in dublicateCars.ToList())
            {
                if ((allCars.PickUpDate >= c.PickUpDate && allCars.PickUpDate <= c.DropOffDate)
                || (allCars.DropOffDate >= c.PickUpDate && allCars.DropOffDate <= c.DropOffDate)
                 )
                {
                    var currCar = cars.FirstOrDefault(x => x.ID == c.CarID);
                    cars.Remove(currCar);
                }
            }
            if (cars.Count == 0)
            {
                string err = "Axtardığınız məntəqədə və seçilən tarixdə maşın yoxdur.";
                var jsonErr = JsonConvert.SerializeObject(err);
                return RedirectToAction("index","home",new {errorBag=jsonErr });
            }
            ViewBag.Searched = Session["searchingInfo"] as VmSearchingCar;
            model.TotalPage = Convert.ToInt32(Math.Ceiling(_context.Cars.Count() / 12.0));
            if (page < 1 || page > model.TotalPage)
            {
                return HttpNotFound();
            }
            model.Cars = cars;
            model.CarModels = _context.CarModels.Include(c => c.Brand).ToList();
            model.Cars.
                Skip((page - 1) * 12).
                Take(12).
                ToList();
            model.Page = page;
            TempData["searchedCars"] = cars;
            TempData["searchingCar"] = allCars;
            return View("car", model);
        }
 
        public ActionResult CarDetail(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            VmCarDetail detailModel = new VmCarDetail();
            detailModel.Car = _context.Cars.Include(m => m.CarModel).Include(m => m.CarModel.Brand).FirstOrDefault(s=>s.ID==id);
            if (detailModel.Car==null)
            {
                return HttpNotFound();
            }
            detailModel.CarModel = _context.CarModels.First();
            detailModel.Brand = _context.Brands.First();
            return View(detailModel);
        }


        #endregion

        public ActionResult SearchAJAX(int? PickUpLocation,int? DropOffLocation,DateTime? PickUpDate,DateTime? DropOffDate, int page = 1)
        {
            List<Car> cars = _context.Cars.Include(m => m.CarModel).Include(m => m.CarModel.Brand).Where(c => c.LocationID == PickUpLocation && c.IsRented == false).ToList();
            List<Order> orders = _context.Orders.ToList();
            var dublicateCars = from c in cars
                                join o in orders
                                on c.ID equals o.CarID
                                select o;
            foreach (var c in dublicateCars.ToList())
            {
                if ((PickUpDate >= c.PickUpDate && PickUpDate <= c.DropOffDate) || (DropOffDate >= c.PickUpDate && DropOffDate <= c.DropOffDate))
                {
                    var currCar = cars.FirstOrDefault(x => x.ID == c.CarID);
                    cars.Remove(currCar);
                }
            }
            if (cars.Count == 0)
            {
                ViewBag.LocationError = "Axtardığınız məntəqədə və seçilən tarixdə maşın yoxdur.";
                return View(model);
            }
            model.TotalPage = Convert.ToInt32(Math.Ceiling(_context.Cars.Count() / 12.0));
            if (page < 1 || page > model.TotalPage)
            {
                return HttpNotFound();
            }
            model.Cars = cars;
            model.CarModels = _context.CarModels.Include(c => c.Brand).ToList();
            model.Cars.
                Skip((page-1)*12).
                Take(12).
                ToList();
            model.Page = page;
            return PartialView("~/Views/Car/CarList.cshtml",model);
        }
    }
}