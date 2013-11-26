using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiraRestClient.Controllers
{
    using System.Configuration;
    using System.Net;
    using System.Text;

    using RestSharp;

    [AllowCrossSiteJson]
    public class BaseController : Controller
    {
        /// <summary>Jira password</summary>
        private string JiraPassword;

        /// <summary>Jira url</summary>
        private string JiraUrl;
        
        /// <summary>Jira username</summary>
        private string JiraUsername;

        /// <summary>
        /// The client
        /// </summary>
        private readonly RestClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssueController"/> class.
        /// </summary>
        public BaseController()
        {
            JiraUrl = ConfigurationManager.AppSettings["JiraUrl"];
            JiraUsername = ConfigurationManager.AppSettings["JiraUsername"];
            JiraPassword = ConfigurationManager.AppSettings["JiraPassword"];

            client = new RestClient { BaseUrl = JiraUrl + (JiraUrl.EndsWith("/") ? "" : "/") + "rest/api/2/" };
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        protected IRestResponse ExecuteRequest(String path)
        {
            var request = new RestRequest { Method = Method.GET, Resource = path, RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", JiraUsername, JiraPassword))));

            var response = client.Execute(request);

            if (response.ErrorException != null)
                throw new ApplicationException("Transport level error: " + response.ErrorMessage, response.ErrorException);

            return response;
        }
    }
}
