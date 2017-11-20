<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>
<asp:Content ID="head" runat="server" ContentPlaceHolderID="CustomHeadContent">
    <script type="text/javascript">

        $(document).ready(function () { corners(); });

        function corners() {
            $(".displayContainerInner").corner("bevel 5px").parent().css('padding', '3px').corner("round keep  10px");
        }

    </script>
</asp:Content>
<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <% var controller = ViewContext.Controller as TicketDesk.Web.Client.Controllers.HomeController; %>
    <div class="contentContainer">
        <div style="max-width: 600px; margin: auto;">
            <div class="displayContainerOuter">
                <div class="displayContainerInner" style="width: 100%;">
                    <div>
                        <div class="activityHeadWrapper">
                            <div class="activityHead">
                                About TicketDesk 2.1
                            </div>
                        </div>
                        <div class="activityBody" style="padding: 15px; min-height: 200px;">
                            <p>
                                <a href="http://ticketdesk.codeplex.com">TicketDesk 2.1</a> is an open source project hosted on <a href="http://codeplex.com">CodePlex</a> and maintained by Stephen Redd.
                            </p>
                            <p>
                                This version deliberately introduces numerous performance issues to demonstrate the sorts of problems which can be experienced when writing ASP.NET applications.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>