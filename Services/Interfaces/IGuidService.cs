namespace mentorship_docker_api.Services.Interfaces
{
    public interface IGuidService
    {
        public Guid Get();
        public Task<string> GetMessageAsync();
    }
}
