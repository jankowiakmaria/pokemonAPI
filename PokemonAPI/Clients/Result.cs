using System.Net;
using System.Net.Http;

namespace PokemonAPI.Clients
{
    public abstract class Result
    {
        public ErrorResultContent ErrorResult { get; private set; }

        public HttpStatusCode StatusCode => ErrorResult.StatusCode;
        public string ErrorMessage => ErrorResult.ErrorMessage;

        public bool Succeeded => ErrorResult is null;
        public bool Failed => ErrorResult != null;

        protected Result()
        {
            ErrorResult = null;
        }

        protected Result(HttpResponseMessage errorResult)
        {
            ErrorResult = new ErrorResultContent(errorResult);
        }

        protected Result(ErrorResultContent errorResult)
        {
            ErrorResult = errorResult;
        }

        private class Success : Result { }

        private class Error : Result
        {
            public Error(HttpResponseMessage errorResult) : base(errorResult) { }
            public Error(ErrorResultContent errorResult) : base(errorResult) { }
        }

        public class ErrorResultContent
        {
            public ErrorResultContent(HttpResponseMessage errorResult)
            {
                StatusCode = errorResult.StatusCode;
                ErrorMessage = errorResult.ReasonPhrase;
            }
            public HttpStatusCode StatusCode { get; private set; }
            public string ErrorMessage { get; private set; }
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
        private Result(ErrorResultContent errorResult) : base(errorResult) { }

        public T Value { get; private set; }

        public static implicit operator Result<T>(T value) => new Result<T>(value);
        public static implicit operator Result<T>(HttpResponseMessage errorResult) =>
            new Result<T>(errorResult);
        public static implicit operator Result<T>(ErrorResultContent errorResult) =>
            new Result<T>(errorResult);

    }
}
