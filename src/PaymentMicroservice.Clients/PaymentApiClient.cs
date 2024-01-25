using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentMicroservice.Contracts.Requests.Price;
using PaymentMicroservice.Contracts.Responses.Price;

namespace PaymentMicroservice.Clients
{
    public class PaymentApiClient
    {
        private readonly HttpClient _httpClient;

        public PaymentApiClient(string baseUrl)
        {
            _httpClient = new HttpClient
            { 
                BaseAddress = new Uri(baseUrl)
            };
        }
        
        private async Task<T> SendRequestAsync<T>(string uri, object request, HttpMethod httpMethod)
        {
            var json = Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var message = new HttpRequestMessage(httpMethod, uri) { Content = content };
            var response = await _httpClient.SendAsync(message);
            
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            var result = Deserialize<T>(responseJson);
            
            return result;
        }
        
        private string Serialize(object obj) => JsonConvert.SerializeObject(obj);
        private T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public async Task<CreatePriceResponse> CreatePriceAsync(CreatePriceRequest request)
        {
            var result = await SendRequestAsync<CreatePriceResponse>("/prices", request, HttpMethod.Post);
            return result;
        }
    }
}