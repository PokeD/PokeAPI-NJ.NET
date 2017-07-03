using System;
using System.IO;
using System.Threading.Tasks;
using PokeAPI;

// 'invalid number' (of next warning suppression)
#pragma warning disable 1692
#pragma warning disable RECS0083
// no 'async' -> block will run synchronously
// not needed, as GetStreamAsync only throws an exn,
// and GetStringAsync creates a Task which result is
// already 'calculated'.
#pragma warning disable 1998

namespace PokeApi.Tests
{
    public class FakeHttpClientAdapter : IHttpClientAdapter
    {
        internal static readonly IHttpClientAdapter Singleton = new FakeHttpClientAdapter();

        public Task<Stream> GetStreamAsync(Uri requestUri) => throw new NotImplementedException();

        public Task<string> GetStringAsync(string requestUri) => Task.FromResult(GetJsonFromFile(requestUri));

        private static string GetJsonFromFile(string requestUri) => File.ReadAllText(Path.Combine(Environment.CurrentDirectory,
            "JsonResponses", requestUri.GenerateSlug() + ".json"));
    }
}