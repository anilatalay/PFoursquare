using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFoursquare.API.Base;
using PFoursquare.API.Model;
using HttpRequest = PFoursquare.API.Helper.HttpRequest;

namespace PFoursquare.API.Controllers.v1
{
    public class VenuesController : BaseController
    {
        // TODO: Url Appsetting Dosyasında Okunabilir
        private readonly string VenuesCategoriesUrl = "https://api.foursquare.com/v2/venues/categories";
        private readonly Dictionary<string, IEnumerable<string>> _headers;
        private readonly StringBuilder _parameters;

        public VenuesController()
        {
            _headers = new Dictionary<string, IEnumerable<string>>
            {
                {ContentTypeHeaderKey, new[] {JsonContentType}}
            };

            _parameters = new StringBuilder();
            _parameters.Append($"{VenuesCategoriesUrl}");
            _parameters.Append("?");
            _parameters.Append($"{VersionHeaderKey}=x");
            _parameters.Append("&");
            _parameters.Append($"{ClientIdHeaderKey}=x");
            _parameters.Append("&");
            _parameters.Append($"{ClientSecretHeaderKey}=x");
        }

        [HttpGet]
        public async Task<ApiReturn<MVenueCategory>> Categories()
        {
            try
            {
                var response = await HttpRequest.GetResponse<MVenueCategory>(_parameters.ToString(), PostMethodName, null, _headers);

                if (response == null)
                    return new ApiReturn<MVenueCategory>
                    {
                        Code = ApiStatusCode.InternalServerError,
                        Message = "Kategoriler Alınamadı"
                    };

                // TODO: MVenueCategory ile RVenueCategory Arasında Mapleme Yapılabilir

                return new ApiReturn<MVenueCategory>
                {
                    Data = response,
                    Code = ApiStatusCode.Success,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                return new ApiReturn<MVenueCategory>
                {
                    Code = ApiStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }
    }
}
