using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PFoursquare.API.Helper;
using PFoursquare.API.Model;
using HttpRequest = Microsoft.AspNetCore.Http.HttpRequest;

namespace PFoursquare.API.Base
{
    [Route("v1/[controller]")]
    public class BaseController : Controller
    {
        protected const string ClientIdHeaderKey = "client_id";
        protected const string ClientIdHeaderValue = "";
        protected const string ClientSecretHeaderKey = "client_secret";
        protected const string ClientSecretHeaderValue = "";
        protected const string VersionHeaderKey = "v";
        protected const string VersionHeaderValue = "20170801";
        protected const string NearHeaderKey = "near";
        protected const string CategoryIdHeaderKey = "categoryId";
        protected const string LocationHeaderKey = "ll";
        protected const string GetMethodName = "GET";
        protected const string ContentTypeHeaderKey = "Content-Type";
        protected const string JsonContentType = "application/json";
        private const string AuthTokenMessage = "Your Auth-Token is not valid.";
        private const string AuthorizationKey = "Auth-Token";
        protected StringBuilder AuthInfo;
        private readonly Guid ExampleGuid;

        public BaseController()
        {
            AuthInfo = new StringBuilder();
            AuthInfo.Append($"{VersionHeaderKey}={VersionHeaderValue}&");
            AuthInfo.Append($"{ClientIdHeaderKey}={ClientIdHeaderValue}&");
            AuthInfo.Append($"{ClientSecretHeaderKey}={ClientSecretHeaderValue}");

            ExampleGuid = Guid.Parse("B91F06CB-BD21-4867-9C35-DB49FD167993");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                // Yetkilendirme İçin [Auth-Token], [App-Id] ve [Client-Secret]
                // Sadece [Auth-Token] Kullanılabilir
                var isValid = false;
                var accessToken = GetHeaderValue(Request, AuthorizationKey);

                if (!string.IsNullOrEmpty(accessToken) && Guid.TryParse(accessToken, out Guid accessTokenGuid) && accessTokenGuid != Guid.Empty)
                {
                    // TODO: Veritabanı Veya Dış Kaynaktan Kontrol Yapılabilir
                    if (accessTokenGuid == ExampleGuid)
                        isValid = true;
                }

                if (!isValid)
                {
                    context.Result = new UnauthorizedObjectResult(new ApiReturn<object>
                    {
                        Code = ApiStatusCode.Unauthorized,
                        Message = AuthTokenMessage,
                        Success = false
                    });
                    return;
                }

                base.OnActionExecuting(context);
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(new ApiReturn<object>
                {
                    Code = ApiStatusCode.InternalServerError,
                    Message = ex.Message,
                    Success = false
                });
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        private string GetHeaderValue(HttpRequest request, string key)
        {
            var headerKeyWithoutDashes = key.Replace("-", "");
            if (!request.Headers.ContainsKey(key) && !request.Headers.ContainsKey(headerKeyWithoutDashes))
                return null;

            var headerValue = request.Headers.First(a => a.Key.Equals(key) || a.Key.Equals(headerKeyWithoutDashes));
            return headerValue.Value.FirstOrDefault();
        }
    }
}
