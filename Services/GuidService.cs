using mentorship_docker_api.Services.Interfaces;
using StackExchange.Redis;

namespace mentorship_docker_api.Services
{
    public class GuidService : IGuidService
    {
        private IConnectionMultiplexer _connectionMultiplexer;
        private IDatabaseAsync _databaseAsync;
        public GuidService (IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _databaseAsync = _connectionMultiplexer.GetDatabase();
        }
        private Guid Id { get; set; }

        public Guid Get()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
            
            return Id;
        }

        private async Task<int> GetCachedAsync()
        {
            int count = 1;
            var redisCount = await _databaseAsync.StringGetAsync("Count");
            if (redisCount.HasValue)
            {
                count = Int32.Parse(count.ToString()) + 1;
            }

            _ = _databaseAsync.StringSetAsync("Count", count.ToString());
            return count;
        }

        public async Task<string> GetMessageAsync()
        {
            int count = await GetCachedAsync();
            string stringId = Get().ToString();
            return "Hi, my name is " + stringId + ", and it`s your " + count.ToString() + " call to us";
        }
    }
}
