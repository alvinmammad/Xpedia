using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpedia.Models;
using Xpedia.ViewModel;

namespace Xpedia.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        VmHome model = new VmHome();
        public ActionResult Index(string errorBag)
        {
            if (errorBag==null)
            {
                VmHome modelBefore = new VmHome
                {
                    Cars = _context.Cars.Include("CarModel").ToList(),
                    CarModel = _context.CarModels.Include("Brand").First(),
                    LogoSliders = _context.LogoSliders.ToList(),
                    ServiceCards = _context.ServiceCards.ToList(),
                    TestimonialItems = _context.TestimonialItems.Include("TestimonialRole").Take(3).ToList(),
                    Blogs = _context.Blogs.Include(b=>b.Author).OrderByDescending(b => b.Date).ToList(),
                    Locations = _context.Locations.ToList(),
                    Setting=_context.Settings.First(),
                    Testimonial=_context.Testimonials.First(),
                    TestimonialRole=_context.TestimonialRoles.First()
                    
                };
                return View(modelBefore);
            }

            string err = JsonConvert.DeserializeObject<string>(errorBag);
            ViewBag.LocationErr = err;

            VmHome model = new VmHome
            {
                Cars = _context.Cars.Include("CarModel").ToList(),
                CarModel = _context.CarModels.Include("Brand").First(),
                LogoSliders = _context.LogoSliders.ToList(),
                ServiceCards = _context.ServiceCards.ToList(),
                TestimonialItems = _context.TestimonialItems.Include("TestimonialRole").Take(3).ToList(),
                Blogs = _context.Blogs.Include("Author").OrderByDescending(b => b.Date).ToList(),
                Locations = _context.Locations.ToList(),
                Setting = _context.Settings.First(),
                Testimonial = _context.Testimonials.First(),
                TestimonialRole = _context.TestimonialRoles.First()
            };

            return View(model);
        }
        [HttpGet]
        public ActionResult GetIndex(VmSearchingCar car)
        {
            VmHome model = new VmHome
            {
                Cars = _context.Cars.Include("CarModel").ToList(),
                CarModel = _context.CarModels.Include("Brand").First(),
                LogoSliders = _context.LogoSliders.ToList(),
                ServiceCards = _context.ServiceCards.ToList(),
                TestimonialItems = _context.TestimonialItems.Include("TestimonialRole").Take(3).ToList(),
                Blogs = _context.Blogs.Include("Author").OrderByDescending(b => b.Date).ToList(),
                Locations = _context.Locations.ToList()
            };
            VmSearchingCar searched = new VmSearchingCar
            {
                PickUpLocation = car.PickUpLocation,
                DropOffLocation = car.DropOffLocation,
                PickUpDate = car.PickUpDate,
                DropOffDate = car.DropOffDate
            };
            var jsonCar = JsonConvert.SerializeObject(searched);
            return RedirectToAction("car", "car", new {searchedCars=jsonCar});
        }
    }
}