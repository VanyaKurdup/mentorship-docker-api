using mentorship_docker_api.Services.Interfaces;

namespace mentorship_docker_api.Services
{
    public class GuidService : IGuidService
    {
        private Guid Id { get; set; }
        public Guid Get()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();

            return Id;
        }
    }
}
