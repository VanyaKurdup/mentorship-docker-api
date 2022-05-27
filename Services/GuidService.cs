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

        public async Task<Guid> GetAsync()
        {
            var cachedId = await _databaseAsync.StringGetAsync("Id");
            if (cachedId.HasValue)
            {
                Id = Guid.Parse(cachedId.ToString());
            }
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
            _ = _databaseAsync.StringSetAsync("Id", Id.ToString());

            return Id;
        }

        public async Task<Guid> GetCachedAsync()
        {
            var cachedId = await _databaseAsync.StringGetAsync("Id");
            if (cachedId.HasValue)
            {
                return Guid.Parse(cachedId.ToString());
            }

             return Guid.Empty;
        }
    }
}
