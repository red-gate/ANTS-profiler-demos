<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<TicketDesk.Web.Client.Models.Engineer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="headContent" ContentPlaceHolderID="CustomHeadContent" runat="server">
    <script type="text/javascript">

        $("document").ready(function () { $("#live-support-request").click(function () { $("#live-support-error").show(); }); cornersHome(); });

        function cornersHome() {
            $(".displayContainerInnerHome").corner("bevel tl 30px").corner("bevel tr 6px").corner("bevel bottom 6px").parent().css('padding', '6px').corner("round keep tl 20px").corner("round keep tr 12px").corner("round keep bottom 12px");
        }

        function connectLiveHelp(Id) {
            $('#livechat').css("color", "#c00");
            $('#livechat').val('Unable to connect');
        }

        
    </script>

       <style type="text/css">
           .engineerphoto
           {
               width:150px;
               margin:10px;
               float:left;
               padding:0;
           }

           .engineercaption
           {
               text-align:center;
               width:150px;
           }

           .engineerphoto a:hover
           {
               background-color: #fff;
               color: #000;
               text-decoration: none;
               text-shadow: none;
           }

.ls-send-button {
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ededed), color-stop(1, #dfdfdf) );
	background:-moz-linear-gradient( center top, #ededed 5%, #dfdfdf 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#ededed', endColorstr='#dfdfdf');
	background-color:#ededed;
	border:1px solid #dcdcdc;
	display:inline-block;
	color:#777777;
	font-family:arial;
	font-size:11px;
	font-weight:normal;
	padding:6px 24px;
	text-decoration:none;
}.ls-send-button:hover {
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #dfdfdf), color-stop(1, #ededed) );
	background:-moz-linear-gradient( center top, #dfdfdf 5%, #ededed 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#dfdfdf', endColorstr='#ededed');
	background-color:#dfdfdf;
}.ls-send-button:active {
	position:relative;
	top:1px;
}
</style>
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width:1000px;margin: auto;">
        <div class="contentContainer">
            <div class="displayContainerOuterHome">
                <div class="displayContainerInnerHome">
                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                        <tbody>
                            <tr>
                                <td style="vertical-align: top; background-color: #fff;">
                                    <div style="padding: 10px;">
                                        <h2>
                                            Live Help portal</h2>
                                        <p>
                                            The following engineers are online. Please choose an engineer to begin.
                                        </p>   
                                        
                                <%
                                    
                                foreach (var engineer in Model)
                                {
                                    %>
                                <div class="engineerphoto">
                                    <a href="javascript:connectLiveHelp(<%:engineer.id%>);">
                                     <img id="engineer-<%:engineer.id%>" width="150" height="150" src="<%= (string)ViewBag.ApiBaseUrl %>/Images/Engineers/150/<%:engineer.id%>.jpg" title="<%:engineer.name%>" alt="<%:engineer.name%>" /> 
                                     <div class="engineercaption"><%:engineer.name%></div>
                                    </a>
                                </div>
                                <%
                                }
                                %>
                                    </div>
                                </td>
                                <td style="width:250px; vertical-align: top; padding: 0px;
                                    border-left: solid 1px #B3CBDF;">
                                    <div style="float: left;">
                                        <div style="padding: 8px;">
                                        
                                            <div style="-moz-border-radius: 15px;border-radius: 15px;height:170px;width:350px;padding:20px;">
                                                <textarea id="livechat" style="color:#aaa;font-size:0.8em;margin-top:90px;width:330px;height:250px" rows="5" cols="50">Choose an engineer</textarea>
                                                <a href="javascript:connectLiveHelp(0);" class="ls-send-button">Send</a>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>