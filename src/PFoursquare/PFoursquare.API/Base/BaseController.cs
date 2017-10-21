using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace PFoursquare.API.Base
{
    [Route("v1/[controller]")]
    public class BaseController : Controller
    {
        protected const string ClientIdHeaderKey = "client_id";
        protected const string ClientIdHeaderValue = "x";
        protected const string ClientSecretHeaderKey = "client_secret";
        protected const string ClientSecretHeaderValue = "x";
        protected const string VersionHeaderKey = "v";
        protected const string VersionHeaderValue = "20170801";
        protected const string GetMethodName = "GET";
        protected const string ContentTypeHeaderKey = "Content-Type";
        protected const string JsonContentType = "application/json";
        protected StringBuilder AuthInfo;

        public BaseController()
        {
            AuthInfo = new StringBuilder();
            AuthInfo.Append($"{VersionHeaderKey}={VersionHeaderValue}&");
            AuthInfo.Append($"{ClientIdHeaderKey}={ClientIdHeaderValue}&");
            AuthInfo.Append($"{ClientSecretHeaderKey}={ClientSecretHeaderValue}");
        }
    }
}
