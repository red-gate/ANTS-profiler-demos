using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.Collections.Specialized;

namespace LiveHelp
{

    public class Status
    {
        public List<string> engineers;
        private string endPoint = "/API/v2.3";
        
        public int getNumberOfOnlineEngineers()
        {

            string apiUrl = "/Engineers/Count/Online";
            string onlineEngineersString;

            onlineEngineersString = executeRequest(apiUrl);

            int number;
            bool result = int.TryParse(onlineEngineersString, out number);

            if (result)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

        public string getListOfOnlineEngineers(string additionalEngineerDetails = "")
        {

            string apiUrl = "/Engineers/List/Online";
            string onlineEngineersString = "";

            NameValueCollection detailParams = new NameValueCollection();
            if (additionalEngineerDetails != "")
            {
                foreach(string detail in additionalEngineerDetails.Split(','))
                {
                    detailParams.Add(detail, "true");
                }
            }
            

            onlineEngineersString = executeRequest(apiUrl, detailParams);

            return onlineEngineersString;
        }

        public string getEngineerNameById(int id)
        {
            string engineerId = id.ToString();
            string apiUrl = "/Engineers/Details/Name/" + engineerId;
            
            string name = executeRequest(apiUrl);
            return name;
        }


        private string executeRequest(string apiUrl, NameValueCollection parameters = null)
        {
            string result;
            string endPoint = ConfigurationSettings.AppSettings["ApiBaseUrl"] + "/API/v2.3";
            using (WebClient client = new WebClient())
            {
                if (parameters != null)
                {
                    foreach (string key in parameters.AllKeys)
                    {
                        client.QueryString.Add(key, parameters[key]);
                    }
                }

                try
                {
                    result = client.DownloadString(endPoint + apiUrl);
                    return result;
                }
                catch (WebException) //just swallow it
                {
                    return "Error";
                }
            };
        }


        //Async implementations - not being used for now.
        public async Task<int> getNumberOfOnlineEngineersAsync()
        {
            string apiUrl = "/Engineers/Count/Online";
            string onlineEngineersString;

            await Task.Delay(1);


            onlineEngineersString = await executeRequestAsync(endPoint, apiUrl);

            int number;
            bool result = int.TryParse(onlineEngineersString, out number);

            if (result)
            {
                return number;
            }
            else
            {
                return 0;
            }

        }

        private async Task<string> executeRequestAsync(string endPoint, string apiUrl)
        {
            await Task.Delay(1);
            string result;
            using (WebClient client = new WebClient())
            {
                try
                {
                    result = client.DownloadString(endPoint + apiUrl);
                    return result;
                }
                catch (WebException)
                {
                    return "Error";
                }
            };
        }

    }
}