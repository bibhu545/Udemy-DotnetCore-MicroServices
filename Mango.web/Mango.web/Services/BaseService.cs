using Mango.web.Models;
using Mango.web.Services.IServices;
using Mango.Web.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mango.web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClientFactory { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.responseModel = new ResponseDto();
            this.httpClientFactory = httpClientFactory;
        }

        public Task<T> SendApiRequest<T>(ApiRequest request)
        {
            try
            {
                var client = this.httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage messsage = new HttpRequestMessage();
                messsage.Headers.Add("Accept", "application/json");
                messsage.RequestUri = new Uri(request.Url);
                client.DefaultRequestHeaders.Clear();
                if (request.Data != null)
                {
                    messsage.Content = new StringContent(JsonConvert.SerializeObject(request.Data),
                        Encoding.UTF8, "application/json");
                }
                HttpResponseMessage response = null;
                switch (request.ApiType)
                {
                    case SD.ApiType.POST:
                        messsage.Method = System.Net.Http.HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        messsage.Method = System.Net.Http.HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        messsage.Method = System.Net.Http.HttpMethod.Get;
                        break;
                    default:
                        messsage.Method = System.Net.Http.HttpMethod.Get;
                        break;
                }
                var apiContent = await response.Content.ReadAsStringAsync();
                response = await client.SendAsync(message);
                var responseDtl = JsonConvert.DeserializeObject<T>(a);
            }
            catch (Exception ex)
            {

            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
