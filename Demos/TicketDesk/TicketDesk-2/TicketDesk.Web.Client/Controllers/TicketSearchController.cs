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
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using TicketDesk.Domain.Services;
using TicketDesk.Domain.Models;
using TicketDesk.Web.Client.Models;

namespace TicketDesk.Web.Client.Controllers
{
    [HandleError]
    [Export("TicketSearch", typeof(IController))]
    public partial class TicketSearchController : ApplicationController
    {
        private TicketSearchService Search { get; set; }
        private ITicketService Tickets { get; set; }
        [ImportingConstructor]
        public TicketSearchController(ITicketService ticketService, TicketSearchService ticketSearch, ISecurityService security)
            : base(security)
        { 
            Search = ticketSearch;
            Tickets = ticketService;
        }

        [Authorize]
        public virtual ActionResult Index(string find)
        {
            try
            {
                if (!string.IsNullOrEmpty(find))
                {
                    string searchParsed;
                    SearchResults searchResults = new SearchResults();
                    TicketSearch ticketSearch = new TicketSearch();
                    searchResults.searchResultList = Search.SearchIndex(Tickets, find, out searchParsed);
                    searchResults.searchResults = ticketSearch.searchForTickets(searchResults.searchResultList, searchParsed, true, this);
                    ViewData.Add("searchPhrase", searchParsed);
                    ViewData.Add("formatForSearch", true);
                    ViewData.Add("searchResults", searchResults.searchResults);
                }
            }
            catch(Exception e) { ViewData.Add("searchPhrase", e); }
            return View();
        }

        //private ITicketService Tickets { get; set; }
        //private SettingsService Settings { get; set; }

        //[ImportingConstructor]
        //public TicketManagerController(ITicketService ticketService, ISecurityService security, SettingsService settings)
        //    : base(security)
        //{
        //    Tickets = ticketService;
        //    Settings = settings;
        //}

        //[Authorize]
        //public virtual ActionResult Index(int? page, string listName)
        //{
        //    var dp = Settings.UserSettings.GetDisplayPreferences();
        //    int p = page ?? 1;
        //    if (string.IsNullOrEmpty(listName))
        //    {
        //        var listPreference = dp.TicketCenterListPreferences.OrderBy(ls => ls.ListMenuDisplayOrder).FirstOrDefault();
        //        if (listPreference != null)
        //        {
        //            listName = listPreference.ListName;
        //        }
        //    }
        //    var lp = dp.GetPreferencesForList(listName);

        //    if (p < 1) //prevent negative pageIndex, redirect to page 1(index 0);
        //    {
        //        return RedirectToAction(MVC.TicketManager.Index(1, listName));
        //    }
        //    var model = new TicketCenterListViewModel(listName, Tickets.ListTickets(p, lp), Settings, Security);

        //    if ( p > 1 && p > model.Tickets.TotalPages)//total pages is 0 when no rows returned, so we only do this when requested page is not page 1.
        //    {
        //        return RedirectToAction(MVC.TicketManager.Index(model.Tickets.TotalPages, listName));
        //    }
        //    if ((TempData["IsRedirectFromAjax"] != null && (bool)TempData["IsRedirectFromAjax"] == true) || this.Request.IsAjaxRequest())
        //    {

        //        //return PartialView(MVC.TicketCenter.Views.Controls.TicketList, model);
        //    }

        //    return View(model);
        //}

    }
}
