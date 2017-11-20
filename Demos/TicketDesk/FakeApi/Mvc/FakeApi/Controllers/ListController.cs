using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FakeApi.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Online()
        {
        string content = @"[
	{""id"": ""872""},
	{""id"": ""233""},
	{""id"": ""421""},
	{""id"": ""104""},
	{""id"": ""460""},
	{""id"": ""220""}
]";

            var rnd = new Random();
            int delay = rnd.Next(300, 600);
            Thread.Sleep(delay);

            return Content(content);
        }
    }
}