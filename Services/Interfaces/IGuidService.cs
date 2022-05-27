namespace mentorship_docker_api.Services.Interfaces
{
    public interface IGuidService
    {
        public Task<Guid> GetAsync();
    }
}
