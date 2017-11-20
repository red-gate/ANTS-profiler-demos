using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;

namespace TicketDeskReporting
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbAccess = new DatabaseAccess();
            var employees = dbAccess.GetListOfHelpDeskEmployees();
            foreach (var employee in employees)
            {
                var performanceData = new EmployeePerformance();
                performanceData = dbAccess.GetEmployeePerformanceData(employee.UserName);
                var hrSystem = new HrSystem();
                hrSystem.UploadEmployeePerformanceData(employee.UserId, performanceData);
            }
        }
    }

    class HrSystem
    {
        public void UploadEmployeePerformanceData(Guid userId, EmployeePerformance performanceData)
        {
            var employeePerformance = SerializeEmployeePerformance(performanceData);
            var date = DateTime.Now.ToString();
            UploadEmployeeFile(userId, "Performance " + date, employeePerformance);
        }

        private string SerializeEmployeePerformance(EmployeePerformance performanceData)
        {
            var categories = SerializeCategories(performanceData.categoryInfo);
            var statuses = SerializeStatuses(performanceData.statusInfo);
            var knowledgeBases = SerializeKnowledgeBases(performanceData.knowledgeBaseInfo);

            var SerializedRawData = categories + "\n" + statuses + "\n" + knowledgeBases;
            
            //just return some raw stuff for now. Later maybe actually calculate some stats
            return SerializedRawData;
        }

        private string SerializeCategories(CategoryCount categories)
        {
            var categoryCountInfo = "Hardware tickets: " + categories.Hardware + ", Network tickets: " + categories.Network + ", Software tickets: " + categories.Software;
            return categoryCountInfo;
        }

        private string SerializeStatuses(StatusCount statuses)
        {
            var statusCountInfo = "Resolved tickets: " + statuses.Resolved + ", Active tickets: " + statuses.Active + ", Closed tickets: " + statuses.Closed + ", More info required: " + statuses.MoreInfo;
            return statusCountInfo;
        }

        private string SerializeKnowledgeBases(KnowledgeBaseCount knowledgeBases)
        {
            var knowledgeBaseCountInfo = "Published to KB: " + knowledgeBases.PublishedToKb + ", Not published to KB: " + knowledgeBases.NotPublishedToKb;
            return knowledgeBaseCountInfo;
        }

        private void UploadEmployeeFile(Guid userId, string fileName, string fileData)
        {
            var uri = ConfigurationManager.AppSettings["HrBaseUrl"] + ConfigurationManager.AppSettings["FileUpload"];
            using (var webClient = new WebClient())
            {
                webClient.Encoding = System.Text.Encoding.UTF8;
                webClient.Headers.Add("X-ApiKey", ConfigurationManager.AppSettings["ApiKey"]);
                webClient.Headers.Add("x-UserId", userId.ToString());
                webClient.Headers.Add("x-FileName", fileName);
                webClient.UploadString(uri, "POST", fileData);
            }
        }
    }


    class DatabaseAccess
    {
        private SqlConnection conn;
        public DatabaseAccess()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Live"].ConnectionString;
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public List<Employee> GetListOfHelpDeskEmployees()
        {
            var query = @"
                SELECT  dbo.aspnet_Users.UserId AS [UserId] ,
                        dbo.aspnet_Users.UserName AS [UserName]
                FROM    dbo.aspnet_Users
                        INNER JOIN dbo.aspnet_UsersInRoles ON dbo.aspnet_UsersInRoles.UserId = dbo.aspnet_Users.UserId
                        INNER JOIN dbo.aspnet_Roles ON dbo.aspnet_Roles.RoleId = dbo.aspnet_UsersInRoles.RoleId
                WHERE   RoleName = 'HelpDesk'
            ";

            var employees = new List<Employee>();
            
            var results = DoDatabaseQuery(query);
            while (results.Read())
            {
                var employee = new Employee
                {
                    UserId = (Guid) results["UserId"],
                    UserName = (string) results["UserName"]
                };
                employees.Add(employee);
            }
            results.Close();
            return employees;
        }

        public EmployeePerformance GetEmployeePerformanceData(string userName)
        {
            var employeePerformance = new EmployeePerformance();
            employeePerformance.categoryInfo = GetCategoryInfo(userName);
            employeePerformance.statusInfo = GetStatusInfo(userName);
            employeePerformance.knowledgeBaseInfo = GetKnowledgeBaseInfo(userName);
            return employeePerformance;
        }

        private CategoryCount GetCategoryInfo(string userName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("username", userName)
            };

            var query = @"
                SELECT  Category AS [Category] ,
                        COUNT(*) AS [Tickets]
                FROM    dbo.Tickets
                WHERE   AssignedTo = @username
                GROUP BY Category 
            ";
            
            var categoryCount = new CategoryCount();
            
            var results = DoDatabaseQuery(query, parameters);
            while (results.Read())
            {
                if ((string) results["Category"] == "Hardware")
                {
                    categoryCount.Hardware = (int)results["Tickets"];    
                }
                if ((string)results["Category"] == "Software")
                {
                    categoryCount.Software = (int)results["Tickets"];
                }
                if ((string)results["Category"] == "Network")
                {
                    categoryCount.Network = (int)results["Tickets"];
                }
            }
            results.Close();
            
            return categoryCount;
        }

        private StatusCount GetStatusInfo(string userName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("username", userName)
            };

            var query = @"
                SELECT  CurrentStatus AS [Status] ,
                        COUNT(*) AS [Tickets]
                FROM    dbo.Tickets
                WHERE   AssignedTo = @username
                GROUP BY CurrentStatus
            ";

            var statusCount = new StatusCount();

            var results = DoDatabaseQuery(query, parameters);
            while (results.Read())
            {
                if ((string)results["Status"] == "Active")
                {
                    statusCount.Active = (int)results["Tickets"];
                }
                if ((string)results["Status"] == "Closed")
                {
                    statusCount.Closed = (int)results["Tickets"];
                }
                if ((string)results["Status"] == "More Info")
                {
                    statusCount.MoreInfo = (int)results["Tickets"];
                }
                if ((string)results["Status"] == "Resolved")
                {
                    statusCount.Resolved = (int)results["Tickets"];
                }
            }
            results.Close();

            return statusCount;
        }

        private KnowledgeBaseCount GetKnowledgeBaseInfo(string userName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("username", userName)
            };

            var query = @"
                SELECT  PublishedToKb AS [Published] ,
                        COUNT(*) AS [Tickets]
                FROM    dbo.Tickets
                WHERE   AssignedTo = @username
                GROUP BY PublishedToKb 
            ";

            var knowledgeBaseCount = new KnowledgeBaseCount();

            var results = DoDatabaseQuery(query, parameters);
            while (results.Read())
            {
                if ((bool)results["Published"])
                {
                    knowledgeBaseCount.PublishedToKb = (int)results["Tickets"];
                }
                else
                {
                    knowledgeBaseCount.NotPublishedToKb = (int)results["Tickets"];
                }
            }
            results.Close();

            return knowledgeBaseCount;
        }


        private SqlDataReader DoDatabaseQuery(string query)
        {
            var parameters = new List<SqlParameter>();
            return DoDatabaseQuery(query, parameters);
        }

        private SqlDataReader DoDatabaseQuery(string query, List<SqlParameter> parameters)
        {
                var command = new SqlCommand(query, conn);
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                var result = command.ExecuteReader();
                return result;
        }
    }

    class Employee
    {
        public Guid UserId;
        public string UserName;
        public EmployeePerformance Performance;
    }

    class EmployeePerformance
    {
        public CategoryCount categoryInfo;
        public StatusCount statusInfo;
        public KnowledgeBaseCount knowledgeBaseInfo;
    }

    class CategoryCount
    {
        public int Hardware = 0;
        public int Network = 0;
        public int Software = 0;
    }

    class StatusCount
    {
        public int Resolved = 0;
        public int Active = 0;
        public int Closed = 0;
        public int MoreInfo = 0;
    }

    class KnowledgeBaseCount
    {
        public int PublishedToKb = 0;
        public int NotPublishedToKb = 0;
    }
}