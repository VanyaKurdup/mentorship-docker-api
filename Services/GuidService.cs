using mentorship_docker_api.Services.Interfaces;

namespace mentorship_docker_api.Services
{
    public class GuidService : IGuidService
    {
        public Guid Get()
        {
            return Guid.NewGuid();
        }
    }
}
