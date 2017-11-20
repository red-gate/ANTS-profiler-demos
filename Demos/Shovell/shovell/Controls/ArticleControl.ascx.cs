using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System;

public partial class ArticleControl : System.Web.UI.UserControl
{
    public ImageButton Vote
    {
        get { return m_vote; }
    }

    public string TitleText
    {
        get { return m_title.Text; }
        set { m_title.Text = value; }
    }

    public string AuthorText
    {
        get { return m_author.Text; }
        set { m_author.Text = value; }
    }

    public string TimeText
    {
        get { return m_time.Text; }
        set { m_time.Text = value; }
    }

    public string ContentsText
    {
        get { return m_contents.Text; }
        set { m_contents.Text = value; }
    }

    public bool CommentsVisible
    {
        get { return m_comments.Visible; }
        set { m_comments.Visible = value; }
    }

    public string ArticleId
    {
        get { return m_vote.CommandArgument; }
        set { HyperLink reply = (HyperLink) m_loginView.FindControl("m_reply");
            if (reply != null) reply.NavigateUrl = "../Submit.aspx?parent=" + value;
            m_vote.CommandArgument = value;
            m_comments.NavigateUrl = "../Default.aspx?article=" + value;
        }
    }

    public string VoteCountText
    {
        get { return m_voteCount.Text; }
        set { m_voteCount.Text = value; }
    }

    /// <summary>
    /// Fill the elements of the article with their values
    /// </summary>
    /// <param name="aArticle">A simple data object with the values, or null to make this invisible</param>
    public void SetData(Article aArticle)
    {
        TitleText = aArticle.Title;
        AuthorText = aArticle.Author;
        TimeText = aArticle.TimeString;
        ContentsText = aArticle.Contents;
        ArticleId = aArticle.Uid;
        VoteCountText = aArticle.Votes.ToString();
    }
}
