using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeAPI
{
    public class HttpClientDefaultAdapter : IHttpClientAdapter
    {
        private readonly HttpClient client = new HttpClient();

        public HttpClientDefaultAdapter()
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("PokeAPI-NJ.NET (https://github.com/PokeD/PokeAPI-NJ.NET or a fork of it)");
        }

        public Task<Stream> GetStreamAsync(Uri requestUri) => client.GetStreamAsync(requestUri);
        public Task<string> GetStringAsync(string requestUri) => client.GetStringAsync(requestUri);
    }
}
