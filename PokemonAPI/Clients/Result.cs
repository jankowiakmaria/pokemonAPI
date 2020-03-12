using System.Net.Http;

namespace PokemonAPI.Clients
{
    public abstract class Result
    {
        private HttpResponseMessage errorResult;

        public bool Succeeded => errorResult is null;
        public bool Failed => errorResult != null;

        protected Result()
        {
            errorResult = null;
        }

        protected Result(HttpResponseMessage errorResult)
        {
            this.errorResult = errorResult;
        }

        private class Success : Result { }

        private class Error : Result
        {
            public Error(HttpResponseMessage errorResult) : base(errorResult) { }
        }

        public static implicit operator Result(HttpResponseMessage errorResult) => new Error(errorResult);
    }

    public class Result<T> : Result
    {
        private Result(T value)
        {
            Value = value;
        }

        private Result(HttpResponseMessage errorResult) : base(errorResult) { }

        public T Value { get; private set; }

        public static implicit operator Result<T>(T value) => new Result<T>(value);
        public static implicit operator Result<T>(HttpResponseMessage errorResult) =>
            new Result<T>(errorResult);
    }
}
