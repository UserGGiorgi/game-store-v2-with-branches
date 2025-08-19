namespace GameStore.Application.Dtos.Games.GetGame
{
    public class PaginatedGamesResponseDto
    {
        public IEnumerable<PaginationGame> Games { get; set; } = new List<PaginationGame>();
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
