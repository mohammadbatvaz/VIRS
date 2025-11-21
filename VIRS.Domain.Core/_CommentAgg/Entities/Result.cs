namespace VIRS.Domain.Core._CommentAgg.Entities
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; }

        public static Result<T> Success(string? message, T? data = default) =>
            new() { IsSuccess = true, Message = message, Data = data };

        public static Result<T> Failure(string? message, T? data = default) =>
            new() { IsSuccess = false, Message = message, Data = data };
    }
}
