using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTotalTech.Models;

namespace TestTotalTech.Services
{
    public class PersonasApi
    {

        public async Task<RootObject> GetPersonas(int c)
        {
            RootObject ro;
            var client = new HttpClient();
            var response = await client.GetAsync("https://randomuser.me/api/?results="+ c);
            var responseString = await response.Content.ReadAsStringAsync();
            ro = JsonConvert.DeserializeObject<RootObject>(responseString);
            return ro;
        }

    }
}
