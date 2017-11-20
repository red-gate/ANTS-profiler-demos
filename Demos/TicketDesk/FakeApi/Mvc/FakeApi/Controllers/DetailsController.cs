using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FakeApi.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Name(int id)
        {
            string name = "";

            if (id == 872)
            {
                name = "John";
            }
            if (id == 233)
            {
                name = "Michael";
            }
            if (id == 421)
            {
                name = "Jeremy";
            }
            if (id == 104)
            {
                name = "Sarah";
            }
            if (id == 460)
            {
                name = "Simon";
            }
            if (id == 220)
            {
                name = "David";
            }

            var rnd = new Random();
            int delay = rnd.Next(500, 1000);
            Thread.Sleep(delay);

            return Content(name);
        }
    }
}