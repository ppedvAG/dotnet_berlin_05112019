using System.Linq;
using System.Net;
using System.Text.Json;

namespace HalloBlazor.Data
{
    class FactsService
    {


        public string GetWichtigeInfo()
        {
            using var wc = new WebClient();
            var json = wc.DownloadString("https://cat-fact.herokuapp.com/facts/");
            CatFacts facts = JsonSerializer.Deserialize<CatFacts>(json);
            return facts.all.First().text;
        }
    }
}
