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

namespace TicketDesk.Web.Client.Models
{
    public class Engineer
    {
        public string id = "0";
        public string name = "";
    }

    public class EngineerDetails
    {
        public List<Engineer> findOnlineEngineers()
        {
            LiveHelp.Status status = new LiveHelp.Status();
            string engineerIdsJson = status.getListOfOnlineEngineers();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Engineer[] engineerIds = js.Deserialize<Engineer[]>(engineerIdsJson);

            List<Engineer> engineerDetails = new List<Engineer>();
            int engineerIdInt;
            foreach (Engineer engineer in engineerIds)
            {
                if (int.TryParse(engineer.id, out engineerIdInt) != null)
                {
                    engineer.name = status.getEngineerNameById(engineerIdInt);
                    engineerDetails.Add(engineer);
                }

            }

            return engineerDetails;
        }
    }

}