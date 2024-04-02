using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using RestSharp;

namespace NWS_API
{
    public class NWS_API_Utility
    {
        //NOT USED, THIS CODE WAS INPUT INTO THE CONDITIONS.CS
        public async void GetAPIConditions()
        {
            var options = new RestClientOptions("https://api.weather.gov/stations/LJAC1/observations/latest");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");//seeing if the api needs this
            var response = await client.GetAsync(request);

            Root data = JsonConvert.DeserializeObject<Root>(response.Content);
                                   
            
        }
    }
}
