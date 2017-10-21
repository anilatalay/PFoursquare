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
        private readonly Dictionary<string, IEnumerable<string>> _headers;

        public VenuesController()
        {
            _headers = new Dictionary<string, IEnumerable<string>>
            {
                {ContentTypeHeaderKey, new[] {JsonContentType}}
            };
        }

        /// <summary>
        /// Get categories of Venues
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

        //[HttpGet]
        //public ApiReturn<string> Search()
        //{
        //    // TODO: Arama Ksımı İçin Bölge Problemine Bakılacak
        //    return null;
        //}

        [HttpGet("{id}")]
        public async Task<ApiReturn<string>> Details(string id)
        {
            try
            {
                if (id == null)
                    return new ApiReturn<string>
                    {
                        Code = ApiStatusCode.InternalServerError,
                        Message = "Id Boş Bırakılamaz."
                    };

                var url = $"{VenuesDetailsUrl}/{id}?{AuthInfo.ToString()}";
                var response = await HttpRequest.GetResponse<MBase>(url, GetMethodName, null, _headers);

                return new ApiReturn<string>
                {
                    Data = null,
                    Code = ApiStatusCode.Success,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                return new ApiReturn<string>
                {
                    Code = ApiStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }
    }
}
