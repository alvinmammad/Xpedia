using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpedia.ViewModel;
namespace Xpedia.Controllers
{
    public class AboutController : BaseController
    {
        // GET: About
        public ActionResult About()
        {
            VmAbout model = new VmAbout
            {
                About = _context.AboutStories.First(),
                Facts = _context.Facts.ToList(),
                Logos = _context.LogoSliders.ToList(),
                Teams = _context.Teams.Include("TeamCategory").ToList()
            };
            return View(model);
        }


    }
}