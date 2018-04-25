using System;
using System.IO;
using System.Threading.Tasks;

namespace PokeAPI
{
    public interface IHttpClientAdapter
    {
        Task<string> GetStringAsync(string requestUri);
        Task<Stream> GetStreamAsync(Uri requestUri);
    }
}
