using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpedia.ViewModel;

namespace Xpedia.Controllers
{
    public class TeamController : BaseController
    {
        // GET: Team
        public ActionResult Team()
        {
            VmTeam model = new VmTeam
            {
                Teams = _context.Teams.Include("TeamCategory").ToList(),
                Drivers = _context.Drivers.ToList(),
                Logos = _context.LogoSliders.ToList()
            };
            return View(model);
        }
    }
}