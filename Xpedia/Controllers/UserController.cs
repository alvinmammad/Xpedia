using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpedia.ViewModel;
using Xpedia.Models;
using System.Data.Entity;
namespace Xpedia.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index(int id)
        {
           
            List<Order> orders = _context.Orders.Include(c=>c.Car).Where(o => o.UserID== id && o.IsConfirmed==true && o.DropOffDate>DateTime.Now && o.DoFinish==false).ToList();
            List<Car> cars = _context.Cars.Include(m => m.CarModel).Include(m => m.CarModel.Brand).ToList();
            List<CarModel> carModels = _context.CarModels.Include(c => c.Brand).ToList();
            List<Brand> brands = _context.Brands.ToList();
            var user = _context.Users.Find(id);
            VmUser model = new VmUser
            {
                User = user,
                Orders = orders,
                Cars = cars,
                Brands = brands,
                CarModels = carModels
            };
            return View(model);
        }

    }
}