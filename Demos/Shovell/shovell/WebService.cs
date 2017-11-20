using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Security;
using System.Web.Services;


/// <summary>
/// Allow access to articles programmatically
/// </summary>
[WebService(Namespace = "http://shovell.red-gate.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<Article> AllArticles()
    {
        //Get *all* of the articles
        List<Article> allArticles = new List<Article>();

        OleDbConnection aConnection =
            new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        aConnection.Open();

        using (OleDbCommand aCommand = new OleDbCommand("SELECT * FROM Articles", aConnection))
        {
            OleDbDataReader reader = aCommand.ExecuteReader();

            while (reader.Read())
            {
                String uid = reader.GetInt32(0).ToString();
                String author = reader.GetString(1);
                DateTime time = reader.GetDateTime(2);
                String title = reader.GetString(3);
                String contents = reader.GetString(4);
                String parent = reader.GetInt32(5).ToString();
                int votes = reader.GetInt32(6);

                allArticles.Add(new Article(uid, author, time, title, contents, parent, votes));
            }
        }

        return allArticles;
    }

    [WebMethod]
    public void SubmitArticle(String username, String password, String title, String contents, String parent)
    {
        //Put a new article in the database

        //First validate the user
        if (!Membership.ValidateUser(username, password))
        {
            //The user doesn't validate
            throw new Exception("The provided username and password were incorrect.");
        }

        //Now actually create the article
        ArticleCreator.CreateArticle(username, title, contents, parent);
    }
    
}

