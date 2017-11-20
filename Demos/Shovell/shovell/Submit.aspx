<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Submit" Codebehind="Submit.aspx.cs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="m_content" Runat="Server">
    &nbsp;<br />
    <asp:Label ID="m_labelTitle" runat="server" Text="Title"></asp:Label><br />
    <asp:TextBox ID="m_title" runat="server"></asp:TextBox><br />
    <asp:Label ID="m_labelContents" runat="server" Text="Contents"></asp:Label><br />
    <asp:TextBox ID="m_contents" runat="server" TextMode="MultiLine"></asp:TextBox><br />
    <asp:LoginView ID="m_loginView" runat="server">
        <LoggedInTemplate>
            <asp:Button ID="m_submit" runat="server" OnClick="m_submit_Click" Text="Submit Article/Comment" />
        </LoggedInTemplate>
        <AnonymousTemplate>
            <asp:Label ID="m_labelAnon" runat="server" Text="You need to be a member to submit a story"></asp:Label>
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>