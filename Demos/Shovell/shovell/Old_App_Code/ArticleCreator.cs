using System;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
/// This stores the data necessary to show an article
/// </summary>
public class ArticleCreator
{
    /// <summary>
    /// Puts a new article in the database
    /// </summary>
    /// <param name="author">The name of the author</param>
    /// <param name="title">The title of the article</param>
    /// <param name="contents">The full html</param>
    /// <param name="parent">The id of the parent</param>
    public static void CreateArticle(String author, String title, String contents, String parent)
    {
        if (string.IsNullOrEmpty(parent))
        {
            //No parent is specified, use "0" to make a top-level story
            parent = "0";
        }

        //Make the update to the database
        using (OleDbConnection aConnection =
            new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            aConnection.Open();

            //The initial vote count is 1
            OleDbCommand aCommand =
                new OleDbCommand(
                    "INSERT INTO Articles ( Author, TimeSubmitted, Title, Contents, Parent, Votes) VALUES " +
                    "(@Author, @Now, @Title, @Contents, @Parent, 1)", aConnection);

            aCommand.Parameters.AddWithValue("Author", author);
            //Take a second from the time, so the page refresh doesn't cause a /0
            aCommand.Parameters.AddWithValue("Now", DateTime.Now.AddSeconds(-1).ToString());
            aCommand.Parameters.AddWithValue("Title", title);
            aCommand.Parameters.AddWithValue("Contents", contents);
            aCommand.Parameters.AddWithValue("Parent", parent);

            aCommand.ExecuteNonQuery();
        }
    }
}