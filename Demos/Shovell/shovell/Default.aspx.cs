using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page 
{
    void Page_Load(Object Sender, EventArgs e)
    {
        String articleID = Request.QueryString["article"];

        //By default, look at the root page
        if (articleID == null)
            articleID = "0";

        if (IsPostBack) return;

        FillMainArticle(articleID);

        //Generate the comments that we'll show on this page
        RedGate.Profiler.UserEvents.ProfilerEvent.SignalEvent("Starting to generate comments");

        if (Boolean.Parse(ConfigurationManager.AppSettings["slowMode"]))
        {
            FillCommentsSlow(articleID);
        }
        else
        {
            FillCommentsFast(articleID);
        }

        RedGate.Profiler.UserEvents.ProfilerEvent.SignalEvent("Finished Generating comments");
    }

    /// <summary>
    /// Takes the (hopefully only 1) article with the id passed, and puts its details in the
    /// ArticleControl.
    /// </summary>
    private void FillMainArticle(String articleID)
    {
        using (OleDbConnection aConnection =
            new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            aConnection.Open();

            OleDbCommand aCommand = new OleDbCommand("SELECT * FROM [Articles] WHERE ([ArticleID] = @ArticleID)", aConnection);

            aCommand.Parameters.AddWithValue("ArticleID", articleID);

            OleDbDataReader reader = aCommand.ExecuteReader();

            if (reader.Read())
            {
                //A row is available - make an Article from it
                String uid = reader.GetInt32(0).ToString();
                String author = reader.GetString(1);
                DateTime time = reader.GetDateTime(2);
                String title = reader.GetString(3);
                String contents = reader.GetString(4);
                String parent = reader.GetInt32(5).ToString();
                int votes = reader.GetInt32(6);

                //Make an Article (largely so the date formatting is unified)
                Article article = new Article(uid, author, time, title, contents, parent, votes);

                //Fill the ArticleControl with the Article
                m_mainArticle.SetData(article);

                m_mainArticle.CommentsVisible = false;

                //Tell the main article's Vote button to call Vote when clicked
                m_mainArticle.Vote.Command += delegate
                                                  {
                                                      Vote(article.Uid);
                                                  };
            }
            else
            {
                //This is most likely the front page, make the ArticleControl invisible
                m_mainArticle.Visible = false;

                //And make the submit new article link visible
                m_sumbitNewLogin.Visible = true;
            }
        }
    }

    /// <summary>
    /// Reads all the articles with the parent passed, then orders them and truncates
    /// the top n. Then binds these to the repeater.
    /// </summary>
    private void FillCommentsSlow(String articleID)
    {
        using (OleDbConnection aConnection =
            new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            aConnection.Open();

            OleDbCommand aCommand = new OleDbCommand("SELECT * FROM [Articles] WHERE ([Parent] = @Parent)",
                                                 aConnection);

            aCommand.Parameters.AddWithValue("Parent", articleID);

            OleDbDataReader reader = aCommand.ExecuteReader();
            List<Article> comments = new List<Article>();

            while (reader.Read())
            {
                //Another row is available - make an Article from it
                String uid = reader.GetInt32(0).ToString();
                String author = reader.GetString(1);
                DateTime time = reader.GetDateTime(2);
                String title = reader.GetString(3);
                String contents = reader.GetString(4);
                String parent = reader.GetInt32(5).ToString();
                int votes = reader.GetInt32(6);

                comments.Add(new Article(uid, author, time, title, contents, parent, votes));
            }

            //Now order by the magic formula
            comments.Sort(delegate(Article a, Article b)
                              {
                                  double valueA = a.Votes/(DateTime.Now - a.Time).TotalDays;
                                  double valueB = b.Votes/(DateTime.Now - b.Time).TotalDays;
                                  int toReturn = Comparer<double>.Default.Compare(valueB, valueA);
                                  return toReturn;
                              });

            //And truncate the resultant list
            int finalLength = Math.Min(int.Parse(ConfigurationManager.AppSettings["pageLength"]), comments.Count);
            comments.RemoveRange(finalLength, comments.Count - finalLength);

            m_repeater.DataSource = comments;
            m_repeater.DataBind();
        }
    }

    /// <summary>
    /// Reads the top n by the magic ordering and binds them directly to the repeater.
    /// The only reason we can't do a completely direct binding is that the repeater
    /// expects a list of Articles (for the slow method) and it would be horrible style
    /// to have Article and the database needing the same field names.
    /// </summary>
    private void FillCommentsFast(String articleID)
    {
        using (OleDbConnection aConnection =
            new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            aConnection.Open();

            //Since the TOP clause can't accept parameters, insert it into the string
            //It's only a configuration option, so injection isn't a problem
            OleDbCommand aCommand =
                new OleDbCommand(
                    "SELECT Top " + ConfigurationManager.AppSettings["pageLength"] +
                    " * FROM [Articles] WHERE ([Parent] = @Parent) ORDER BY (Votes/(Now() - TimeSubmitted)) DESC",
                    aConnection);

            aCommand.Parameters.AddWithValue("Parent", articleID);

            OleDbDataReader reader = aCommand.ExecuteReader();
            List<Article> comments = new List<Article>();

            while (reader.Read())
            {
                //Another row is available - make an Article from it
                String uid = reader.GetInt32(0).ToString();
                String author = reader.GetString(1);
                DateTime time = reader.GetDateTime(2);
                String title = reader.GetString(3);
                String contents = reader.GetString(4);
                String parent = reader.GetInt32(5).ToString();
                int votes = reader.GetInt32(6);

                comments.Add(new Article(uid, author, time, title, contents, parent, votes));
            }

            m_repeater.DataSource = comments;
            m_repeater.DataBind();
        }
    }

    /// <summary>
    /// This gets called when any of the comments' vote button is pressed
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void RepeaterCommand(object source, RepeaterCommandEventArgs e)
    {
        //The article to vote for is in the CommandArgument
        Vote((String)e.CommandArgument);
    }

    /// <summary>
    /// Increments the number of votes for an article.
    /// </summary>
    /// <param name="articleID">The article to vote up.</param>
    public static void Vote(String articleID)
    {
        using (OleDbConnection aConnection =
            new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            aConnection.Open();

            OleDbCommand aCommand =
                new OleDbCommand("UPDATE Articles SET Votes = Votes + 1 WHERE (ArticleID = @ArticleID)",
                               aConnection);

            aCommand.Parameters.AddWithValue("ArticleID", articleID);

            aCommand.ExecuteNonQuery();
        }
    }
}
