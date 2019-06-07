using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpedia.ViewModel;
namespace Xpedia.Controllers
{
    public class ServiceController : BaseController
    {
        // GET: Service
        public ActionResult Service()
        {
            VmService model = new VmService
            {
                Service = _context.Services.First(),
                Cards = _context.ServiceCards.ToList(),
                Testimonial = _context.Testimonials.First(),
                TestimonialItems = _context.TestimonialItems.Include("TestimonialRole").ToList(),
                Logos=_context.LogoSliders.ToList()
            };
            return View(model);
        }
    }
}