// TicketDesk - Attribution notice
// Contributor(s):
//
//      Stephen Redd (stephen@reddnet.net, http://www.reddnet.net)
//
// This file is distributed under the terms of the Microsoft Public 
// License (Ms-PL). See http://ticketdesk.codeplex.com/license
// for the complete terms of use. 
//
// For any distribution that contains code from this file, this notice of 
// attribution must remain intact, and a copy of the license must be 
// provided to the recipient.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using TicketDesk.Domain.Services;
using System.Threading.Tasks;
using LiveHelp;
using TicketDesk.Web.Client.Models;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Glimpse.Core.Extensions;

namespace TicketDesk.Web.Client.Controllers
{
    [HandleError]
    [Export("Home", typeof(IController))]
    public partial class HomeController : ApplicationController
    {
        [ImportingConstructor]
        public HomeController(ISecurityService security)
            : base(security)
        {
        }

        public virtual ActionResult Index()
        {
            LiveHelp.Status status = new LiveHelp.Status();
            int onlineEngineers = status.getNumberOfOnlineEngineers();

            ViewData["onlineEngineers"] = onlineEngineers;
            return View();
        }

        public virtual ActionResult About()
        {
            return View("AboutRazor");
        }

        public virtual ActionResult Status()
        {
            return View(StatusBoard.OpeningStatus.CheckWhetherLiveHelpSystemIsOpen() ? "StatusOnline" : "StatusOffline");
        }


        public virtual ActionResult LiveHelp()
        {
            EngineerDetails engineerDetails = new EngineerDetails();
            List<Engineer> engineerNamesList = engineerDetails.findOnlineEngineers();       
            ViewBag.ApiBaseUrl = ConfigurationSettings.AppSettings["ApiBaseUrl"];
            return View(engineerNamesList);
     
        }
    }

}