using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FakeApi.Controllers
{
    public class HRSystemController : Controller
    {
        // GET: HRSystem
        public ActionResult AddFile()
        {
            var rnd = new Random();
            int delay = rnd.Next(800, 3000);
            Thread.Sleep(delay);
            return Content("");
        }
    }
}