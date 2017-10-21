using Microsoft.AspNetCore.Mvc;

namespace PFoursquare.API.Helper
{
    public class UnauthorizedObjectResult : ObjectResult
    {
        public UnauthorizedObjectResult(object value) : base(value)
        {
            StatusCode = 401;
        }
    }
}
