using Newtonsoft.Json;
using OneLine.Wep.Models;
using OneLine.Wep.Service.IService;
using System.Net;
using System.Text;
using static OneLine.Wep.Utility.SD;


namespace OneLine.Wep.Service
{
    public class BaseServiceImpl : IBaseService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BaseServiceImpl(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task<ResponseDTO?> SendAsync(Request request)
        {
            HttpClient client = _httpClientFactory.CreateClient("OneLineAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            // token

            message.RequestUri = new Uri(request.Url);
            if (request.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
            }

            // to config message method
            message.Method = request.ApiType switch
            { 
                ApiType.POST => HttpMethod.Post,
                ApiType.PUT => HttpMethod.Put,
                ApiType.DELETE => HttpMethod.Delete,
                _ => HttpMethod.Get
            };


            return await HandelReponse(client, message);
        }

        private async Task<ResponseDTO?> HandelReponse(HttpClient client, HttpRequestMessage message)
        {
            HttpResponseMessage apiResponse = await client.SendAsync(message);

            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "NotFound" };

                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Access Denied" };

                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "Unauthorized" };

                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, Message = "Internal Server Error" };

                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                    return apiResponseDTO;

            }
        }
    }
}
