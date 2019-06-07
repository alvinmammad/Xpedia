using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Xpedia.Models;
using Xpedia.ViewModel;

namespace Xpedia.Controllers
{
    public class OrderController : BaseController
    {
        public ActionResult Order(int id)
        {
            if (id == 0 && id < 0)
            {
                return HttpNotFound();
            }
            var searchingCar = TempData["searchingCar"] as VmSearchingCar;
            var selectedCar = _context.Cars.Include(c => c.CarModel).Include(c => c.CarModel.Brand).Where(c => c.ID == id).FirstOrDefault();
            var carModel = _context.CarModels.First();
            var carBrand = _context.Brands.First();
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "register", new { ReturnURL = Request.Url.AbsoluteUri.ToString() });
            }
            var user = Session["LoginnedUser"] as User;
            var pickLocation = _context.Locations.Find(searchingCar.PickUpLocation);
            var dropLocation = _context.Locations.Find(searchingCar.DropOffLocation);
            VmCarCheckout model = new VmCarCheckout
            {
                SearchingCar = searchingCar,
                SelectedCar = selectedCar,
                User = user,
                CarModel = carModel,
                Brand = carBrand
            };
            Random random = new Random();
            var a = random.Next(1, 999999);
            while (_context.Orders.Any(o=> o.OrderNumber == a))
            {
                 a = random.Next(1, 999999);
            }
            Order order = new Order {
                UserID=user.ID,
                OrderNumber = a,
                PickUpLocation=pickLocation.Name,
                DropOffLocation=dropLocation.Name,
                PickUpDate=model.SearchingCar.PickUpDate,
                DropOffDate=model.SearchingCar.DropOffDate,
                CarID=id
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            int ID = order.ID;
            model.OrderNumber = a;

            VmOrder orderModel = new VmOrder
            {
                PickUpLocation = pickLocation.Name,
                DropOffLocation = dropLocation.Name,
                SelectedCar = selectedCar,
                User = user,
                CarModel = carModel,
                Brand = carBrand,
                OrderNumber=a,
                DropOffDate=searchingCar.DropOffDate,
                PickUpDate=searchingCar.PickUpDate
            };
            return View(orderModel);
        }
    }
}