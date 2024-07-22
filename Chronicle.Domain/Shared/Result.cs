namespace Chronicle.Domain.Shared
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string? Error { get; }

        protected Result(string? error)
        {
            IsSuccess = string.IsNullOrEmpty(error);
            Error = error;
        }

        public static Result Success => new(null);

        public static Result Failure(string error) => new(error);
    }

    public class Result<T>(T value, string? error) : Result(error)
    {
        public T Value { get; } = value;
    }
}
