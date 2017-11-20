using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;


namespace Api.Controllers
{
    public class MembersController : Controller
    {
        public ActionResult Images(int memberId)
        {
            var random = new Random();
            int randomDelay = random.Next(2000, 3000);
            Thread.Sleep(randomDelay);

            int imgNumber = memberId % 10;

            var imgPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Images/" + imgNumber + ".jpg");
            Image img = Image.FromFile(imgPath);
            MemoryStream ms = new MemoryStream();
            
            img.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;

            HttpContext.Response.Headers.Add("X-Original-Size", "4500x6300");
            return new FileStreamResult(ms, "image/jpeg");
        }
    }
}