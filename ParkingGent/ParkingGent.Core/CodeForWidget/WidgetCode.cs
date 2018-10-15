using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParkingGent.Core.Models;

namespace ParkingGent.Core.CodeForWidget
{
    public class WidgetCode
    {
        public WidgetCode()
        {
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            // client.DefaultRequestHeaders.Add("user-key", _API_KEY);
            return client;
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            using (HttpClient client = CreateHttpClient())
            {
                try
                {
                    //   var json = await client.GetStringAsync(url);
                    var json = Task.Run(() => client.GetStringAsync(url));
                    var r = json.Result;
                    return await Task.Run(() => JsonConvert.DeserializeObject<T>(r));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return default(T);
                }
            }
        }

        private const string _BASEURL = "https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime.json";
        private List<Parking> _parkings;

        public async Task<List<Parking>> GetParkings()
        {
            string url = _BASEURL;
            _parkings = await GetAsync<List<Parking>>(url);

            return _parkings;
        }
    }
}