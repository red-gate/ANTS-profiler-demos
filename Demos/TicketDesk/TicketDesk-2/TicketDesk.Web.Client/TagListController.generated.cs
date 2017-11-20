// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace TicketDesk.Web.Client.Controllers
{
    public partial class TagListController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected TagListController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult AutoComplete()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AutoComplete);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public TagListController Actions { get { return MVC.TagList; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "TagList";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "TagList";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string AutoComplete = "AutoComplete";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string AutoComplete = "AutoComplete";
        }


        static readonly ActionParamsClass_AutoComplete s_params_AutoComplete = new ActionParamsClass_AutoComplete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AutoComplete AutoCompleteParams { get { return s_params_AutoComplete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AutoComplete
        {
            public readonly string q = "q";
            public readonly string limit = "limit";
            public readonly string timestamp = "timestamp";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_TagListController : TicketDesk.Web.Client.Controllers.TagListController
    {
        public T4MVC_TagListController() : base(Dummy.Instance) { }

        partial void AutoCompleteOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string q, int limit, string timestamp);

        public override System.Web.Mvc.JsonResult AutoComplete(string q, int limit, string timestamp)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AutoComplete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "q", q);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "limit", limit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "timestamp", timestamp);
            AutoCompleteOverride(callInfo, q, limit, timestamp);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591