using System;
using System.Web.Security;

public partial class Submit : System.Web.UI.Page
{
    protected void m_submit_Click(object sender, EventArgs e)
    {
        //Create a new story
        String parent = Request.QueryString["parent"];

        //Find the logged-on author
        String author = Membership.GetUser().ToString();

        ArticleCreator.CreateArticle(author, m_title.Text, m_contents.Text, parent);

        //And send the user back to see parent
        Response.Redirect("Default.aspx?article=" + parent);
    }
}
