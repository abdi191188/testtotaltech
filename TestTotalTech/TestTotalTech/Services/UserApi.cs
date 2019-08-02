using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTotalTech.Models;

namespace TestTotalTech.Services
{
    public class UserApi
    {
        private const string url = "https://reqres.in/api/login";

        public async Task<bool> LoginOn(string email, string password)
        {
            bool b = false;
            try
            {
                using (var c = new HttpClient())
                {
                    var client = new System.Net.Http.HttpClient();
                    var jsonRequest = new { email = email, password = password };
                    var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
                    HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    if (response.IsSuccessStatusCode)
                    {
                        Resultado result = JsonConvert.DeserializeObject<Resultado>(response.Content.ReadAsStringAsync().Result);
                        if (!string.IsNullOrEmpty(result.token))
                        {
                            Session s = new Session();
                            s.User = email;
                            s.Password = password;
                            s.Token = result.token;
                            b = true;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return b;
        }

    }

    public class Resultado
    {
        public string token { get; set; }
    }
}
