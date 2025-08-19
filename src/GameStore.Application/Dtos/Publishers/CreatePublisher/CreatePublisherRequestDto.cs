using GameStore.Application.Dtos.Publishers.GetPublisher;

namespace GameStore.Application.Dtos.Publishers.CreatePublisher
{
    public class CreatePublisherRequestDto
    {
        public PublisherDto Publisher { get; set; } = new();
    }
}
