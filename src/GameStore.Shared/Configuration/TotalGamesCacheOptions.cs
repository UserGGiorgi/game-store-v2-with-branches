namespace GameStore.Shared.Configuration
{
    public class TotalGamesCacheOptions
    {
        public const string SectionName = "TotalGamesCacheOptions";
        public int CacheExpirationMinutes { get; set; } = 1;
    }
}
