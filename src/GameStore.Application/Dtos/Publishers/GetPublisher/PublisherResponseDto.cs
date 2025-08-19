namespace GameStore.Application.Dtos.Publishers.GetPublisher
{
    public class PublisherResponseDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string HomePage { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
