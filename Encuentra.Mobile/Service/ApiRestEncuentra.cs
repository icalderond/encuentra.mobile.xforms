using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Encuentra.Mobile.Model;

namespace Encuentra.Mobile.Service
{
    public class ApiRestEncuentra
    {
        const string HostApi = @"http://192.168.1.69:3000/api/v1/";
        const string EndPointChurches = @"iglesias/{0}";
        const string EndPointCities = @"iglesias/estados";
        private readonly HttpClient client;
        public event EventHandler<GenericEventArgs<List<City>>> GetCities_Completed;
        public event EventHandler<GenericEventArgs<List<Church>>> GetChurchesFromCity_Completed;

        public ApiRestEncuentra()
        {
            client = new HttpClient { MaxResponseContentBufferSize = 256000 };
        }

        public async void GetCities()
        {
            var uri = new Uri(HostApi + EndPointCities);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(content);
                var Items = jObject["response"].Children().ToList().Select(x => x.ToObject<City>()).ToList();
                GetCities_Completed?.Invoke(this, new GenericEventArgs<List<City>>(Items));
            }
        }

        public async void GetChurchesFromCity(string _city)
        {
            var uri = new Uri(string.Format(HostApi + EndPointChurches, _city));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(content);
                var Items = jObject["response"].Children().ToList().Select(x => x.ToObject<Church>()).ToList();
                GetChurchesFromCity_Completed?.Invoke(this, new GenericEventArgs<List<Church>>(Items));
            }
        }
    }
}