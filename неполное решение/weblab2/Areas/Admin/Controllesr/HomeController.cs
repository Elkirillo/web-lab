using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weblab2.Domain;

namespace weblab2.Areas.Admin.Controllesr
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            return View(dataManager.ServiceItem.GetServiceitems());
        }
    }
}
