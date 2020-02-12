using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WP_Test.Models;
using WP_Test;

namespace WP_Test.DataProviders
{
    public class PeopleDataProvider : IPeopleDataProvider
    {
        string _baseAddress = "https://bpdts-test-app.herokuapp.com/";

        public async Task<IEnumerable<Person>> GetPeopleAsync(string query)
        {                        
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMessage = await client.GetAsync(_baseAddress + query);
               

                if (responseMessage.IsSuccessStatusCode)
                {                    
                    return await responseMessage.Content.ReadAsJsonAsync<List<Person>>();   
                }

                return await Task.FromResult<IEnumerable<Person>>(null);
            }
        }

    }
}
