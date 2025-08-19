namespace GameStore.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public object? Errors { get; }

        public BadRequestException(string message, object? errors = null)
            : base(message)
        {
            Errors = errors;
        }
    }
}
