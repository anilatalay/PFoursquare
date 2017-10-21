using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PFoursquare.API.Helper
{
    public static class HttpRequest
    {
        private const string JsonContentType = "application/json";
        private const string GetMethodName = "GET";

        public static async Task<T> GetResponse<T>(string address, string method, object content,
            Dictionary<string, IEnumerable<string>> headers)
        {
            try
            {
                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback =
                        (message, cert, chain, errors) => true;

                    using (var http = new HttpClient(httpClientHandler))
                    {
                        var requestMessage = new HttpRequestMessage();
                        requestMessage.Headers.Clear();

                        requestMessage.Headers.Accept.Clear();
                        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

                        foreach (var header in headers)
                        {
                            if (!requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray()))
                            {
                                requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key,
                                    header.Value.ToArray());
                            }
                        }

                        var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8,
                            JsonContentType);
                        requestMessage.Content = stringContent;

                        requestMessage.RequestUri = new Uri(address);
                        requestMessage.Method = new HttpMethod(method);

                        if (method == GetMethodName)
                        {
                            requestMessage.Content = null;
                        }

                        var response = await http.SendAsync(requestMessage);
                        var data = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<T>(data);
                    }
                }
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
    }
}
