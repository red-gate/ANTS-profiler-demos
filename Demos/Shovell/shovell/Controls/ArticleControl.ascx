<%@ Control Language="C#" AutoEventWireup="true" Inherits="ArticleControl" Codebehind="ArticleControl.ascx.cs" %>

<div class="WhiteItem" style="height: 90px">
    <div class="VotesBox">
        <small>
            <asp:ImageButton ID="m_vote" runat="server" ImageUrl="../Content/Thumbup.gif" />
            <br />
            <p class="VotesTotal">
                <asp:Label ID="m_voteCount" runat="server" />
            </p>
            <br />
        </small>
    </div>
    
    <div class="SuggestionTextBox">
        <h3 class="suggestionTitle"><asp:Label ID="m_title" runat="server" /></h3>
        <div>
            <asp:Label ID="m_contents" runat="server" />
        </div>

        <div style="width:40%; float: left;"><small><b>Author:</b> <asp:Label ID="m_author" runat="server" /></small></div>
        <div style="margin: 0px 40px; float: left;"><small>
            <asp:HyperLink ID="m_comments" runat="server" ><img src="Content/Comment.gif" />Comments</asp:HyperLink>
        </small></div>
        <div style="margin: 0px 40px; float: left;"><small>
            <asp:Label ID="m_time" runat="server" />
        </small></div>
        <div style="margin: 0px 40px; float: left;"><small>
            <asp:LoginView ID="m_loginView" runat="server">
                <LoggedInTemplate>
                    <asp:HyperLink ID="m_reply" runat="server" >Reply</asp:HyperLink>
                </LoggedInTemplate>
            </asp:LoginView>
        </small></div>
    </div>
    <br />

</div>