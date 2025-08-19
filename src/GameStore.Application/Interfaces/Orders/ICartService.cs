namespace GameStore.Application.Interfaces.Orders
{
    public interface ICartService
    {
        Task AddToCartAsync(string gameKey);
        Task RemoveFromCartAsync(string gameKey);

    }
}
