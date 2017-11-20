using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace LibraryManager
{
    public partial class QueryRunner : Form
    {
        private const string Listing2 = @"
SELECT TOP (1) 
    [Extent1].[Id] AS [Id], 
    [Extent1].[MemberId] AS [MemberId], 
    [Extent1].[StartDate] AS [StartDate], 
    [Extent1].[DueDate] AS [DueDate], 
    [Extent1].[FineIncurred] AS [FineIncurred], 
    [Extent1].[BookInstanceId] AS [BookInstanceId], 
    [Extent1].[Returned] AS [Returned], 
    [Extent1].[FinePaid] AS [FinePaid]
FROM [dbo].[Loans] AS [Extent1]
WHERE [Extent1].[StartDate] < (SysDateTime())
ORDER BY [Extent1].[StartDate] DESC;
";

        private const string Listing4 = @"
SELECT 
    [GroupBy1].[A1] AS [C1]
FROM ( SELECT 
    SUM([Filter1].[A1]) AS [A1]
    FROM ( SELECT 
        CASE WHEN ([Extent1].[FineIncurred] IS NULL)
            THEN CAST(0 as decimal(18))
            ELSE [Extent1].[FineIncurred] END AS [A1]
        FROM [dbo].[Loans] AS [Extent1]
        WHERE 0 =  CAST( [Extent1].[FinePaid] AS int)
    )  AS [Filter1]
)  AS [GroupBy1];
";

        private const string Listing8 = @"
SELECT 
    [GroupBy1].[A1] AS [C1]
    FROM ( SELECT 
        COUNT(1) AS [A1]
        FROM [dbo].[Loans] AS [Extent1]
        WHERE (0 =  CAST( [Extent1].[Returned] AS int))         AND ([Extent1].[DueDate] < (SysDateTime()))
    )  AS [GroupBy1];
";

        private const string Listing10 = @"
SELECT  Id ,
        MemberId ,
        StartDate ,
        DueDate ,
        FineIncurred ,
        BookInstanceId ,
        Returned ,
        FinePaid
FROM    dbo.Loans
WHERE   DueDate BETWEEN CURRENT_TIMESTAMP
                AND     DATEADD(DAY, 14, CURRENT_TIMESTAMP)
        AND Returned = 0
ORDER BY DueDate DESC;
"; 
    
        public QueryRunner()
        {
            InitializeComponent();
        }

        private void buttonListing2_Click(object sender, EventArgs e)
        {
            var query = Listing2;
            CheckResultCount(query);
        }

        private void buttonListing4_Click(object sender, EventArgs e)
        {
            var query = Listing4;
            CheckResultCount(query);
        }

        private void buttonListing8_Click(object sender, EventArgs e)
        {
            var query = Listing8;
            CheckResultCount(query);
        }

        private void buttonListing10_Click(object sender, EventArgs e)
        {
            var query = Listing10;
            CheckResultCount(query);
        }

        private void CheckResultCount(string query)
        {
            labelResult.Text = "Running query.";
            labelResult.Refresh();
            try
            {
                int results = RunQuery(query);
                labelResult.Text = results + " results were returned.";
            }
            catch (SqlException)
            {
                labelResult.Text = "Couldn't connect to database. Try changing the connection string in app.config.";
            }
            
        }

        private int RunQuery(string query)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryManagerDb"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var sqlCommand = new SqlCommand(query, conn))
                {
                    
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        int records = 0;
                        while (reader.Read())
                        {
                            records++;
                        }
                        return records;
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.simple-talk.com/sql/performance/basic-sql-server-performance-troubleshooting-for-developers/");
        }
    }
}