using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FakeApi.Controllers
{
    public class CountController : Controller
    {
        // GET: Count
        public ActionResult Online()
        {
            DateTime now = DateTime.Now;
            DateTime lastRequest = CountRateLimit.LastRequest;
            double difference = now.Subtract(lastRequest).TotalSeconds;
            if (difference <= 2)
            {
                Thread.Sleep(10000);
                Response.Headers.Add("X-RateLimit-Throttled:", "API request rate too high - 10 second penalty imposed.");
            }
            CountRateLimit.LastRequest = DateTime.Now;

            var rnd = new Random();
            int online = rnd.Next(5, 8);
            return Content(online.ToString());
        }
    }

    public static class CountRateLimit
    {
        public static DateTime LastRequest = DateTime.Now.AddSeconds(-5);
    }
}