using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class HttpHelpers
    {
        private static JsonSerializerSettings _setting;
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpHelpers(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        static HttpHelpers()
        {
            _setting = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }


        public async Task<TR> PostAsync<T, TR>(string url, T body)
        {
            var newBody = JsonConvert.SerializeObject(body, _setting);

            var requestBody = new StringContent(newBody);

            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsync(url, requestBody);

            var responseBody = await response.RequestMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TR>(responseBody, _setting);
        }


        public async Task<TR> GetAsync<TR>(string url)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<TR>(response, _setting);
        }
    }
}
