using System.Threading.Tasks;
using System.Net.Http;

namespace LanguageFeatures.Models
{
    public static class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("https://lowcygier.pl/");

            return httpMessage.Content.Headers.ContentLength;
        }
    }
}