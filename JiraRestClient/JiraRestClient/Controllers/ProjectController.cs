using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiraRestClient.Controllers
{
    using RestSharp;

    public class ProjectController : BaseController
    {
        public ContentResult Get(string id)
        {
            var response = this.ExecuteRequest(string.Format("project/{0}", id));
            return Content(response.Content, response.ContentType);
        }
    }
}
