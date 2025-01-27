using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    class FactAPIVM
    {
        public static async Task<string> GetRandomFact()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(Constants.RANDOM_FACT_API);
                var json = await response.Content.ReadAsStringAsync();
                var fact = JsonConvert.DeserializeObject<Fact>(json);

                return fact == null ? "Could not generate random fact, do you have internet access?" : fact.text;
            }
            catch (Exception) // bijvoorbeeld als er geen internet is
            {
                return "No internet connection available: try again later !";
            }
        }
    }
}
