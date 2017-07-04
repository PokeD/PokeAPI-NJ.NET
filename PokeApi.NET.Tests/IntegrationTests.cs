using System.Threading.Tasks;
using PokeAPI;
using Xunit;

namespace PokeAPI.Tests.IntegrationTests
{
    public class Tests
    {
        [Fact]
        public async Task GetsMove()
        {
            var t = await DataFetcher.GetApiObject<Move>(1);
            Assert.NotNull(t);
        }

        [Fact]
        public async Task GetsAbility()
        {
            var t = await DataFetcher.GetApiObject<Ability>(1);
            Assert.NotNull(t);
        }
        
        [Fact]
        public async Task GetsItem()
        {
            var t = await DataFetcher.GetApiObject<Item>(1);
            Assert.NotNull(t);
        }
    }
}