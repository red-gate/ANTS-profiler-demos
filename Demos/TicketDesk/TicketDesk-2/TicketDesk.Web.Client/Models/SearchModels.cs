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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicketDesk.Domain.Services;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using TicketDesk.Domain.Models;
using TicketDesk.Web.Client.Models;
using TicketDesk.Web.Client.Helpers;
using TicketDesk.Web.Client.Controllers;

namespace TicketDesk.Web.Client.Models
{
    public class SearchResults
    {
        public IEnumerable<Ticket> searchResultList;
        public string searchResults = "";
    }

    public class TicketSearch
    {
        public string searchForTickets(IEnumerable<Ticket> results, string searchParsed, bool formatForSearch, ApplicationController controller)
        {
            string searchResults = "";
            foreach (Ticket item in results)
            {
                searchResults += "<div class=\"displayContainerOuter\" style=\"width:75%;\">";
                searchResults += "\n";
                searchResults += "<div class=\"displayContainerInner\">";

                var currentFlagStatus = item.CurrentStatus.Replace(" ", "").ToLower();
                if (string.IsNullOrEmpty(item.AssignedTo) && item.CurrentStatus != "Closed")
                {
                    currentFlagStatus = "unassigned";
                }
                string root = "";

                var flagUrl = root + VirtualPathUtility.ToAbsolute(string.Format("~/Content/{0}Flag.png", currentFlagStatus));

                var ticketUrl = root + VirtualPathUtility.ToAbsolute(string.Format("~/Ticket/{0}", item.TicketId.ToString()));

                string detailsHeight = formatForSearch ? "200" : "70";

                searchResults += "<div class=\"ticketDetailsHeaderOuter\">";
                searchResults += "<div class=\"";
                searchResults += currentFlagStatus;
                searchResults += "Flag ticketDetailsHeaderInner\">";
                searchResults += "<div class=\"statusFlag\">";
                searchResults += "<img alt=\"";
                searchResults += currentFlagStatus;
                searchResults += "\" src=\"";
                searchResults += flagUrl;
                searchResults += "\" />";
                searchResults += "</div>";

                searchResults += "<div class=\"ticketDetailsTopper\">";
                searchResults += "<div class=\"ticketDetailsHeader\">";

                if (!string.IsNullOrEmpty(item.Priority))
                {

                    searchResults += "<div class=\"ticketDetailsHeaderPriority\">";
                    searchResults += "<div>";
                    searchResults += "Priority:";
                    searchResults += item.Priority;
                    searchResults += "</div>";
                    searchResults += "</div>";

                }

                searchResults += "<div class=\"ticketDetailsHeaderId\">";
                searchResults += "<a href=\"";
                searchResults += ticketUrl;
                searchResults += "\">Ticket: #";
                searchResults += item.TicketId;
                searchResults += " - ";
                searchResults += item.Category;
                searchResults += item.Type;
                searchResults += "</a>";
                searchResults += "</div>";
                searchResults += "<div class=\"ticketDetailsHeaderTitle\">";
                searchResults += item.Title;
                searchResults += "</div>";
                searchResults += "<div class=\"ticketDetailsHeaderInfo\">";

                if (!string.IsNullOrEmpty(item.TagList))
                {

                    searchResults += "<div class=\"ticketDetailsHeaderTagsArea\">";
                    searchResults += "<span>";
                    searchResults += "Tags:";
                    searchResults += item.TagList;
                    searchResults += "</span>";
                    searchResults += "</div>";

                }

                searchResults += "<div style=\"padding: 2px;\">";
                searchResults += "<div style=\"white-space: nowrap;\">";
                searchResults += "<span class=\"ticketDetailsHeaderInfoLabel\" style=\"display:inline-block;\">";
                searchResults += "Assigned To:";
                searchResults += "</span>";
                searchResults += "&nbsp;";
                searchResults += "<span class=\"ticketDetailsHeaderAssignedTo ticketDetailsHeaderInfoText\">";
                searchResults += item.GetAssignedToDisplayName(controller);
                searchResults += "</span>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "<div style=\"padding: 2px;\">";
                searchResults += "<div style=\"white-space: nowrap;\">";
                searchResults += "<span class=\"ticketDetailsHeaderInfoLabel\" style=\"display:inline-block;\">";
                searchResults += " Owned By:";
                searchResults += "</span>";
                searchResults += "&nbsp;";
                searchResults += "<span class=\"ticketDetailsHeaderInfoText\">";
                searchResults += item.GetOwnerDisplayName(controller);
                searchResults += "</span>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "<div class=\"ticketDetailsOuter\">";
                searchResults += "<div class=\"ticketDetailsInner\">";
                searchResults += "<div>";
                searchResults += "<div class=\"detailsTextWrapper\" id=\"detailsText\" ";
                searchResults += "style=\"height: ";
                searchResults += detailsHeight;
                searchResults += "px;\"";
                searchResults += ">";
                searchResults += item.HtmlDetails;
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "</div>";
                searchResults += "\n";
                searchResults += "</div>";
            }
            if (searchResults.Count() > 0)
            {
                return searchResults;
            }
            else
            {
                searchResults = "<div style=\"width:90%;text-align:center; padding:25px;\">";
                searchResults += "There are no tickets to display.";
                searchResults += "</div>";
                return searchResults;
            }
        }
    }

}