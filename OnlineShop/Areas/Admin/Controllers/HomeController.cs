using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class Home1Controller : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}