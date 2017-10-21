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
        private readonly string VenuesDetailsUrl = "https://api.foursquare.com/v2/venues";
        private readonly string VenuesSearchUrl = "https://api.foursquare.com/v2/venues/search";
        private readonly Dictionary<string, IEnumerable<string>> _headers;

        public VenuesController()
        {
            _headers = new Dictionary<string, IEnumerable<string>>
            {
                {ContentTypeHeaderKey, new[] {JsonContentType}}
            };
        }

        /// <summary>
        /// Get categories of venues
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiReturn<List<RCategory>>> Categories()
        {
            try
            {
                var url = $"{VenuesCategoriesUrl}?{AuthInfo.ToString()}";
                var response = await HttpRequest.GetResponse<MBase>(url, GetMethodName, null, _headers);

                if (response == null)
                    return new ApiReturn<List<RCategory>>
                    {
                        Code = ApiStatusCode.InternalServerError,
                        Message = "Kategoriler Alınamadı"
                    };

                var categories = AutoMapper.Mapper.Map<List<RCategory>>(response.Response.Categories);

                return new ApiReturn<List<RCategory>>
                {
                    Data = categories,
                    Code = ApiStatusCode.Success,
                    Message = "OK"
                };
            }
            catch (Exception ex)
            {
                return new ApiReturn<List<RCategory>>
                {
                    Code = ApiStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// Get venues by criteria
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<ApiReturn<List<RVenue>>> Search([FromBody] MSearch value)
        {
            try
            {
                if (value == null)
                    return new ApiReturn<List<RVenue>>
                    {
                        Code = ApiStatusCode.InternalServerError,
                        Message = "Id Boş Bırakılamaz."
                    };

                // TODO: Arama Kısmı İçin Filter Yazılabilir
                var parameters = new StringBuilder();
                if (value.Area != null)
                    parameters.Append($"{NearHeaderKey}={value.Area}&");

                if (value.CategoryId != null)
                    parameters.Append($"{CategoryIdHeaderKey}={value.CategoryId}&");

                if (value.Location != null)
                    parameters.Append($"{LocationHeaderKey}={value.Location}&");

                var url = $"{VenuesSearchUrl}?{parameters.ToString()}{AuthInfo.ToString()}";
                var response = await HttpRequest.GetResponse<MBase>(url, GetMethodName, null, _headers);
                if (response == null)
                    return new ApiReturn<List<RVenue>>
                    {
                        Code = ApiStatusCode.InternalServerError,
                        Message = "Mekan Alınamadı"
                    };

                var venues = AutoMapper.Mapper.Map<List<RVenue>>(response.Response.Venues);

                return new ApiReturn<List<RVenue>>
                {
                    Data = venues,
                    Code = ApiStatusCode.Success,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                return new ApiReturn<List<RVenue>>
                {
                    Code = ApiStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// Get a detail of venues
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ApiReturn<RVenue>> Details(string id)
        {
            try
            {
                if (id == null)
                    return new ApiReturn<RVenue>
                    {
                        Code = ApiStatusCode.InternalServerError,
                        Message = "Id Boş Bırakılamaz."
                    };

                var url = $"{VenuesDetailsUrl}/{id}?{AuthInfo.ToString()}";
                var response = await HttpRequest.GetResponse<MBase>(url, GetMethodName, null, _headers);

                if (response == null)
                    return new ApiReturn<RVenue>
                    {
                        Code = ApiStatusCode.InternalServerError,
                        Message = "Detaylar Alınamadı"
                    };

                var details = AutoMapper.Mapper.Map<RVenue>(response.Response.Venue);

                return new ApiReturn<RVenue>
                {
                    Data = details,
                    Code = ApiStatusCode.Success,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                return new ApiReturn<RVenue>
                {
                    Code = ApiStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }
    }
}
