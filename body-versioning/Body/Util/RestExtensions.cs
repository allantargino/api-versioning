using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Body.Util
{
    public static class RestExtensions
    {
        public static async Task<TData> GetObject<TData>(this HttpClient client, string requestUri)
        {
            var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TData>(responseString);
        }

        public static async Task<TData> PostObject<TData>(this HttpClient client, string requestUri, object value)
        {
            var strContent = JsonConvert.SerializeObject(value);
            var content = new StringContent(strContent, Encoding.ASCII, "application/json");
            var response = await client.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TData>(responseString);
        }
    }
}
