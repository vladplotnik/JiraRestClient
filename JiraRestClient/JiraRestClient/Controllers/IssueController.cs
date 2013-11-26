using System.Web.Mvc;

namespace JiraRestClient.Controllers
{
    public class IssueController : BaseController
    {
        /// <summary>
        /// Searches the specified JQL.
        /// </summary>
        /// <param name="jql">The JQL.</param>
        /// <param name="startAt">The start at.</param>
        /// <param name="maxResults">The maximum results.</param>
        /// <param name="validateQuery">The validate query.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="expand">The expand.</param>
        /// <returns></returns>
        public ContentResult Search(string jql, int? startAt, int? maxResults, bool? validateQuery, string fields, string expand)
        {
            var response = this.ExecuteRequest(
                string.Format(
                    "search?jql={0}&startAt={1}&maxResults={2}&validateQuery={3}&fields={4}&expand={5}",
                    jql,
                    startAt ?? 0,
                    maxResults ?? 50,
                    validateQuery ?? true,
                    fields,
                    expand));
            return Content(response.Content, response.ContentType);
        }

        /// <summary>
        /// Searches the specified key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ContentResult Get(string id)
        {
            var response = this.ExecuteRequest(string.Format("issue/{0}", id));
            return Content(response.Content, response.ContentType);
        }

        /// <summary>
        /// Comments the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ContentResult Comment(string id)
        {
            var response = this.ExecuteRequest(string.Format("issue/{0}/comment", id));
            return Content(response.Content, response.ContentType);
        }

        public ContentResult Worklog(string id)
        {
            var response = this.ExecuteRequest(string.Format("issue/{0}/worklog", id));
            return Content(response.Content, response.ContentType);
        }
    }
}
