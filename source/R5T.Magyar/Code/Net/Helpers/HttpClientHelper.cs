using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace R5T.Magyar.Net
{
    public static class HttpClientHelper
    {
        public static async Task<string> GetStringAsync(string url)
        {
            using(var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                return result;
            }
        }
    }
}
