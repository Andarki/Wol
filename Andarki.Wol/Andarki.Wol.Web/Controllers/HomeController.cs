using Andarki.Wol;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Andarki.Wol.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var wolConfigurationSection = ConfigurationManager.GetSection("MachinesSection") as WolConfigurationSection;

            return View(wolConfigurationSection.Machines);
        }
    }
}
