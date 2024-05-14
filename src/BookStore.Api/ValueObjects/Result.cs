namespace BookStore.Api.ValueObjects
{
    public class Result<T>
    {
        public Dictionary<string, string[]> Errors { get; } = [];
        public T? Data { get; }
        public bool IsSuccess => Errors.Count == 0;

        public Result(string key, string[] values)
        {
            Errors.Add(key, values);
        }

        public Result(Dictionary<string, string[]> errorMessages)
        {
            foreach (var item in errorMessages)
                Errors.Add(item.Key, item.Value);
        }

        public Result(T data)
        {
            Data = data;
        }
    }
}