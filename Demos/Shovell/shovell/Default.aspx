<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="_Default"  Codebehind="Default.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="m_content" Runat="Server">

    <div id="headerArticle">
        <uc1:ArticleControl id="m_mainArticle" runat="server"/>
    </div>
    <asp:Repeater ID="m_repeater" runat="server" OnItemCommand="RepeaterCommand">
        <ItemTemplate>
            <uc1:ArticleControl ID="m_articleControlRepeated" runat="server" 
             TitleText='<%# Eval("Title") %>'
             AuthorText='<%# Eval("Author") %>'
             ContentsText='<%# Eval("Contents") %>'
             TimeText='<%# Eval("TimeString") %>'
             ArticleId='<%# Eval("Uid") %>'
             VoteCountText='<%# Eval("Votes") %>'/>
        </ItemTemplate>
    </asp:Repeater>
    <asp:LoginView ID="m_sumbitNewLogin" runat="server" Visible="False">
        <LoggedInTemplate>
            <asp:HyperLink ID="m_submitNewLink" runat="server" NavigateUrl="Submit.aspx">Submit New Article</asp:HyperLink>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>