using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace PFoursquare.API.Base
{
    [Route("v1/[controller]")]
    public class BaseController : Controller
    {
        protected const string ClientIdHeaderKey = "client_id";
        protected const string ClientSecretHeaderKey = "client_secret";
        protected const string VersionHeaderKey = "v";
        protected const string PostMethodName = "GET";
        protected const string ContentTypeHeaderKey = "Content-Type";
        protected const string JsonContentType = "application/json";
    }
}
