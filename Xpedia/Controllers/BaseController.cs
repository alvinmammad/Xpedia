using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Xpedia.DAL;
namespace Xpedia.Controllers
{
    public class BaseController : Controller
    {
        protected readonly XpediaContext _context = new XpediaContext();

        public BaseController()
        {
            ViewBag.Contact = _context.Contacts.First();
            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Setting = _context.Settings.ToList();
            ViewBag.LogoSlider = _context.LogoSliders.ToList();
            ViewBag.Tag = _context.Tags.ToList();
            ViewBag.Latest = _context.Blogs.OrderByDescending(b=>b.Date).Take(4).ToList();
            ViewBag.LatestCars = _context.Cars.Take(3).ToList();
            ViewBag.Locations = _context.Locations.ToList();
        }
    }
}