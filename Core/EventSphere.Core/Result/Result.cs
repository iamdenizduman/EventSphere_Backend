using EventSphere.Core.Enums;
using EventSphere.Core.Result.Interfaces;

namespace EventSphere.Core.Result
{
    public class Result(ResultStatus resultStatus) : IResult
    {
        public string Message { get; } = string.Empty;
        public ResultStatus ResultStatus { get; } = resultStatus;
        public Exception? Exception { get; }

        public Result(ResultStatus resultStatus, string message) : this(resultStatus)
        {
            Message = message;
        }
        public Result(ResultStatus resultStatus, Exception exception) : this(resultStatus)
        {
            Exception = exception;
        }
        public Result(ResultStatus resultStatus, string message, Exception exception) : this(resultStatus, message)
        {
            Exception = exception;
        }
    }
}
