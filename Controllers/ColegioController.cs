using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Colegio.Controllers
{
    public class ColegioController : Controller
    {
        // GET: Colegio
        public ActionResult Index()
        {
            return View();
        }
    }
}